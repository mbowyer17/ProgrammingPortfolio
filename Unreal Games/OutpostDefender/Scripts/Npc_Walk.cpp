// Fill out your copyright notice in the Description page of Project Settings.


#include "Npc_Walk.h"
#include "Engine/DamageEvents.h"
#include "Kismet/GameplayStatics.h"
#include "Npc_Projectile.h"

// Sets default values
ANpc_Walk::ANpc_Walk()
{
 	// Set this character to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	Health = 40.f;

	MuzzleLocation = CreateDefaultSubobject<USceneComponent>(TEXT("MuzzleLocation"));
	MuzzleLocation->SetupAttachment(RootComponent); // Attach to the root or another component
}

// Called when the game starts or when spawned
void ANpc_Walk::BeginPlay()
{
	Super::BeginPlay();
	
}

// Called every frame
void ANpc_Walk::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

// Called to bind functionality to input
void ANpc_Walk::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);

}

void ANpc_Walk::Death()
{
	
		Destroy();
	
}

float ANpc_Walk::TakeDamage(float DamageAmount, FDamageEvent const& DamageEvent, AController* EventInstigator, AActor* DamageCauser)
{
	// Reduce health by the damage amount
	Health -= DamageAmount;

	// Check for death
	if (Health <= 0)
	{
		Death(); // Call the death function
	}

	// Return the damage amount
	return DamageAmount;
}

void ANpc_Walk::Shoot()
{

	// Get current time 
	float CurrentTime = GetWorld()->GetTimeSeconds();
	//Check if enough time has passed since last shot
	if (CurrentTime - LastShotTime < ShootCooldown)
	{
		// Exit the function
		return;
	}
	// Check if null
	if (ProjectileClass != nullptr)
	{
		// GET ROTATION AND LOCATION
		FVector MuzzleLocationVec = MuzzleLocation->GetComponentLocation();
		FRotator MuzzleRotation = MuzzleLocation->GetComponentRotation();

		// Spawn
		ANpc_Projectile* Projectile = GetWorld()->SpawnActor<ANpc_Projectile>(ProjectileClass, MuzzleLocationVec, MuzzleRotation);
		
		// Update the last shot time
		LastShotTime = CurrentTime;
	}
}



