// Fill out your copyright notice in the Description page of Project Settings.


#include "Outpost.h"
#include "Components/BoxComponent.h"
#include "Engine.h"
#include "Engine/DamageEvents.h"

// Sets default values
AOutpost::AOutpost()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	CollisionComponent = CreateDefaultSubobject<UBoxComponent>(TEXT("Collision"));
    CollisionComponent->InitBoxExtent(FVector(150.f, 150.f, 150.f));
	RootComponent = CollisionComponent;

	Health = 100.f;
}

// Called when the game starts or when spawned
void AOutpost::BeginPlay()
{
	Super::BeginPlay();
	Tags.Add("OutpostTag");
}

// Called every frame
void AOutpost::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

void AOutpost::TakeNpcDamage(float DamageAmount, FDamageEvent const& DamageEvent, AController* EventInstigator, AActor* DamageCauser)
{
	// Reduce health by the damage amount
	Health -= DamageAmount;
	FString HealthString = FString::Printf(TEXT("Health: %f"), Health);

	// Check for death
	if (Health <= 0)
	{
		Death(); // Call the death function
	}
	GEngine->AddOnScreenDebugMessage(
		-1,                   // Key (use -1 to keep replacing the same message instead of adding new ones)
		5.0f,                 // How many seconds the message should appear on the screen
		FColor::Green,        // The color of the text
		HealthString          // The message text, which is now the health value converted to text
	);
	
	// Return the damage amount
	return;
}

void AOutpost::Death()
{
	Destroy();
}

void AOutpost::OnHit(UPrimitiveComponent* HitComponent, AActor* OtherActor, UPrimitiveComponent* OtherComp, FVector NormalImpulse, const FHitResult& Hit)
{
	

	// Check if the other actor is valid and not this projectile
	if (OtherActor && (OtherActor != this))
	{
		
	}

	// Destroy the projectile
	Destroy();
}

void AOutpost::AddHealth(float HealthAdd)
{
	Health += HealthAdd;
}



