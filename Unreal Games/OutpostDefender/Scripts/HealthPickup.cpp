// Fill out your copyright notice in the Description page of Project Settings.


#include "HealthPickup.h"
#include "Components/BoxComponent.h"
#include "Outpost.h"
#include "AdvancedTPCharacter.h"

// Sets default values
AHealthPickup::AHealthPickup()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	MeshComponent = CreateDefaultSubobject<UStaticMeshComponent>(TEXT("MeshComponent"));
	RootComponent = MeshComponent;

	CollisionComponent = CreateDefaultSubobject<UBoxComponent>(TEXT("CollisionComponent"));
	CollisionComponent->SetupAttachment(RootComponent);
}

void AHealthPickup::NotifyActorBeginOverlap(AActor* OtherActor)
{

	AAdvancedTPCharacter* PlayerCharacter = Cast<AAdvancedTPCharacter>(OtherActor);

	if (Outpost && PlayerCharacter)
	{
		Outpost->AddHealth(20.0f); // Adjust the health value as needed
		Destroy();
	}
}

// Called when the game starts or when spawned
void AHealthPickup::BeginPlay()
{
	Super::BeginPlay();
	
}

// Called every frame
void AHealthPickup::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	
}

