// Fill out your copyright notice in the Description page of Project Settings.


#include "RocketProjectile.h"
#include "GameFramework/ProjectileMovementComponent.h"
#include "Components/SphereComponent.h"
#include "Kismet/GameplayStatics.h"
#include "GameFramework/Character.h"

// Sets default values
ARocketProjectile::ARocketProjectile()
{
    // Set this actor to call Tick() every frame
    PrimaryActorTick.bCanEverTick = true;

    // Create the Collision Component
    CollisionComponent = CreateDefaultSubobject<USphereComponent>(TEXT("CollisionComponent"));
    CollisionComponent->InitSphereRadius(10.0f);
    CollisionComponent->OnComponentHit.AddDynamic(this, &ARocketProjectile::OnHit);
    RootComponent = CollisionComponent;

    // Create the Projectile Movement Component
    ProjectileMovementComponent = CreateDefaultSubobject<UProjectileMovementComponent>(TEXT("ProjectileMovementComponent"));
    ProjectileMovementComponent->UpdatedComponent = CollisionComponent;
    ProjectileMovementComponent->InitialSpeed = 1000.0f;
    ProjectileMovementComponent->MaxSpeed = 1000.0f;
    ProjectileMovementComponent->bShouldBounce = true;

    // Set the default damage radius
    DamageRadius = 300.0f;
}

void ARocketProjectile::OnHit(UPrimitiveComponent* HitComponent, AActor* OtherActor, UPrimitiveComponent* OtherComp, FVector NormalImpulse, const FHitResult& Hit)
{

    if (OtherActor && OtherActor != this && OtherComp)
    {
        // Check if the hit actor is a character
        ACharacter* HitCharacter = Cast<ACharacter>(OtherActor);

        if (HitCharacter)
        {
            // Calculate the distance between the impact point and the player
            float DistanceToPlayer = FVector::Distance(Hit.ImpactPoint, HitCharacter->GetActorLocation());

            // Calculate a scale factor for the launch power based on the distance (you might need to adjust the formula to get the desired effect)
            float LaunchPowerScale = FMath::Clamp(1.0f - DistanceToPlayer / DamageRadius, 0.0f, 1.0f);

            // Apply the scaled launch power when launching the player
            LaunchPlayer(HitCharacter, LaunchPower * LaunchPowerScale);

            Destroy();
        }
        else
        {
            // Handle interaction with other objects (e.g., explode on impact)
            Explode();
        }
    }
}

void ARocketProjectile::Explode()
{
    // Call the Blueprint event to handle explosion visuals and effects
    OnRocketExplode();

    // Check for actors in the damage radius
    TArray<AActor*> ActorsToIgnore;
    ActorsToIgnore.Add(this);

    TArray<FHitResult> HitResults;
    FVector StartLocation = GetActorLocation();
    FVector EndLocation = StartLocation + FVector::UpVector; // Adjust the direction as needed

    FCollisionShape CollisionShape;
    CollisionShape.SetSphere(DamageRadius);

    if (GetWorld()->SweepMultiByChannel(HitResults, StartLocation, EndLocation, FQuat::Identity, ECC_Visibility, CollisionShape, FCollisionQueryParams()))
    {
        for (const FHitResult& HitResult : HitResults)
        {
            ACharacter* PlayerCharacter = Cast<ACharacter>(HitResult.GetActor());
            if (PlayerCharacter)
            {
                // Launch the player character in the opposite direction
                LaunchPlayer(PlayerCharacter, LaunchPower); // Adjust the launch speed as needed
                
            }
        }
    }

    // Destroy the rocket projectile after the explosion
    //Destroy();
}

void ARocketProjectile::LaunchPlayer(ACharacter* PlayerCharacter, float LaunchSpeed)
{
    if (PlayerCharacter)
    {
        FVector LaunchDirection = -GetActorForwardVector(); // Launch in the opposite direction of the rocket
        PlayerCharacter->LaunchCharacter(LaunchDirection * LaunchSpeed, false, false);
    }
}
