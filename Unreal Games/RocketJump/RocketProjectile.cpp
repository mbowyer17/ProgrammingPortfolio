// Fill out your copyright notice in the Description page of Project Settings.

#include "RocketProjectile.h"
#include "GameFramework/ProjectileMovementComponent.h"
#include "Components/SphereComponent.h"
#include "Kismet/GameplayStatics.h"
#include "GameFramework/Character.h"
#include "Engine/EngineTypes.h"
#include "Kismet/KismetSystemLibrary.h"

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
    Explode();

}

void ARocketProjectile::Explode()
{
    TArray<AActor*> IgnoredActors;
    IgnoredActors.Add(this);

    TArray<AActor*> AffectedActors;

    // Specify object types. In this example, we're checking against pawns.
    TArray<TEnumAsByte<EObjectTypeQuery>> ObjectTypes;
    ObjectTypes.Add(UEngineTypes::ConvertToObjectType(ECollisionChannel::ECC_Pawn));

    // Find all actors within the explosion radius.
    UKismetSystemLibrary::SphereOverlapActors(GetWorld(), GetActorLocation(), ExplosionRadius, ObjectTypes, ACharacter::StaticClass(), IgnoredActors, AffectedActors);

    for (AActor* Actor : AffectedActors)
    {
        // Check if the hit actor is a character
        ACharacter* HitCharacter = Cast<ACharacter>(Actor);
        if (HitCharacter)
        {
            FVector LaunchDirection = Actor->GetActorLocation() - GetActorLocation();
            LaunchDirection.Normalize();

            // Apply the scaled launch power when launching the player
            LaunchPlayer(HitCharacter, LaunchPower);

            Destroy();
        }
    }


}

void ARocketProjectile::LaunchPlayer(ACharacter* PlayerCharacter, float LaunchSpeed)
{
    if (PlayerCharacter)
    {
        FVector LaunchDirection = -GetActorForwardVector(); // Launch in the opposite direction of the rocket
        PlayerCharacter->LaunchCharacter(LaunchDirection * LaunchSpeed, false, false);
    }
}