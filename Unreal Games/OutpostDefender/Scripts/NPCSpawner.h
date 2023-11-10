// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "NPCSpawner.generated.h"

UCLASS()
class PROJECTTWO_API ANPCSpawner : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	ANPCSpawner();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

	UPROPERTY(EditDefaultsOnly, Category = "Spawning")
	TSubclassOf<AActor> NPCClass;

	// Reference to the Safehouse actor
	AActor* OutpostActor;

	// List of Outpost Actors
	TArray<AActor*> FoundActors;

	// Time handle for spawning Actors
	FTimerHandle SpawnTimerHandle;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;


	void SpawnNpcsAroundOutpost();
};
