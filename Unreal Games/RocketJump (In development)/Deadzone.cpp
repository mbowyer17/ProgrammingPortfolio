// Fill out your copyright notice in the Description page of Project Settings.


#include "Deadzone.h"
#include "Components/BoxComponent.h"
#include "GameFramework/PlayerController.h"
#include "GameFramework/ProjectileMovementComponent.h"
#include "GameFramework/Character.h"

// Sets default values
ADeadzone::ADeadzone()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	// Create the collision box component
	CollisionBox = CreateDefaultSubobject<UBoxComponent>(TEXT("CollisionBox"));
	RootComponent = CollisionBox;

	// Bind the overlap function
	CollisionBox->OnComponentBeginOverlap.AddDynamic(this, &ADeadzone::OnPlayerEnterDeadZone);

}

// Called when the game starts or when spawned
void ADeadzone::BeginPlay()
{
	Super::BeginPlay();
	
}

// Called every frame
void ADeadzone::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

void ADeadzone::OnPlayerEnterDeadZone(UPrimitiveComponent* OverlappedComp, AActor* OtherActor, UPrimitiveComponent* OtherComp, int32 OtherBodyIndex, bool bFromSweep, const FHitResult& SweepResult)
{
	// Check if the overlapped actor is the player character
	APlayerController* PlayerController = Cast<APlayerController>(OtherActor->GetInstigatorController());

	if (PlayerController)
	{
		// Teleport the player to the Spawn location
		OtherActor->SetActorLocation(SpawnLocation);
	}


}
