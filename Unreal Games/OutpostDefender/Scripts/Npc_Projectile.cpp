// Fill out your copyright notice in the Description page of Project Settings.


#include "Npc_Projectile.h"
#include "Components/SphereComponent.h"
#include "GameFramework/ProjectileMovementComponent.h"
#include "Engine/World.h"
#include "GameFramework/Actor.h"
#include "Kismet/GameplayStatics.h"
#include "Outpost.h"
#include "Engine/DamageEvents.h"
#include "Components/StaticMeshComponent.h"

// Sets default values
ANpc_Projectile::ANpc_Projectile()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	// CollisionComponent
	/*
	CollisionComponent = CreateDefaultSubobject<USphereComponent>(TEXT("Collision"));
	CollisionComponent->InitSphereRadius(15.f);
	CollisionComponent->BodyInstance.SetCollisionProfileName("Projectile");
	RootComponent = CollisionComponent;
	*/

	

	// Mesh

	CollisionComponent = CreateDefaultSubobject<USphereComponent>(TEXT("Collision"));
	CollisionComponent->InitSphereRadius(15.f);
	CollisionComponent->BodyInstance.SetCollisionProfileName(TEXT("Projectile"));
	CollisionComponent->OnComponentHit.AddDynamic(this, &ANpc_Projectile::OnHit);  // Bind the OnHit event
	RootComponent = CollisionComponent;

	// Projectile Movement component
	ProjectileMovement = CreateDefaultSubobject<UProjectileMovementComponent>(TEXT("Projectile"));
	ProjectileMovement->SetUpdatedComponent(CollisionComponent);
	ProjectileMovement->InitialSpeed = 3000.f;
	ProjectileMovement->MaxSpeed = 3000.f;
	ProjectileMovement->bRotationFollowsVelocity = true;
	ProjectileMovement->bShouldBounce = false;
}

// Called when the game starts or when spawned
void ANpc_Projectile::BeginPlay()
{
	Super::BeginPlay();
	

	// Find the target 
	AActor* LocalTargetActor = FindTargetActorByName(TEXT("BP_Outpost"));

	if (LocalTargetActor)
	{
		// Calculate Direction towards Target
		FVector TargetLocation = LocalTargetActor->GetActorLocation();
		FVector ProjectileLocation = GetActorLocation();
		FVector Direction = (TargetLocation - ProjectileLocation).GetSafeNormal();

		if (ProjectileMovement)
		{
			ProjectileMovement->Velocity = Direction * ProjectileMovement->MaxSpeed;
		}

	}
	// Set the life span
	InitialLifeSpan = 3.0f;
}

// Called every frame
void ANpc_Projectile::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

void ANpc_Projectile::InitVelocity(const FVector& ShootDirection)
{
	if (ProjectileMovement)
	{
		ProjectileMovement->Velocity = ShootDirection * ProjectileMovement->InitialSpeed;
	}
}

AActor* ANpc_Projectile::FindTargetActorByName(FName TargetTag)
{
	// Use a TActorIterator<AActor> to find the actor called BP_SafeHouse
	UGameplayStatics::GetAllActorsWithTag(GetWorld(), FName(TargetTag), FoundActors);

	// If there is at least one actor with the 'SafehouseTag' tag
	if (FoundActors.Num() > 0)
	{
		// Assume the first found actor is the one you want
		return FoundActors[0];
	}
	else
	{
		
		return nullptr;
	}
	
}

void ANpc_Projectile::OnHit(UPrimitiveComponent* HitComponent, AActor* OtherActor, UPrimitiveComponent* OtherComp, FVector NormalImpulse, const FHitResult& Hit)
{
	

		// Check if the other actor is valid and not this projectile
		if (OtherActor && (OtherActor != this))
		{
			// Cast the OtherActor to your NPC class, if necessary
			AOutpost* HitOutpost = Cast<AOutpost>(OtherActor);
			if (HitOutpost)
			{
				GEngine->AddOnScreenDebugMessage(
					-1,                 // Key (use -1 to keep replacing the same message instead of adding new ones)
					5.0f,               // How many seconds the message should appear on the screen
					FColor::Green,      // The color of the text
					TEXT("ITS WORKING"));      // The message text
				// Apply damage
				HitOutpost->TakeNpcDamage(1.f, FDamageEvent(UDamageType::StaticClass()), nullptr, this);
			
				Destroy();
			}
		}

		// Destroy the projectile
		Destroy();
	
}

