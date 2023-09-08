// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "Deadzone.generated.h"

UCLASS()
class PORTFOLIOWORK_API ADeadzone : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	ADeadzone();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

	// Collision Box for the dead zone
	UPROPERTY(VisibleAnywhere)
	class UBoxComponent* CollisionBox;

	// SpawnLocation where the player will be teleported
	UPROPERTY(EditAnywhere)
	FVector SpawnLocation;

	// Function that handles overlap with the player
	UFUNCTION()
	void OnPlayerEnterDeadZone(class UPrimitiveComponent* Overlapped, class AActor* OtherActor, class UPrimitiveComponent* OtherComp, int32 OtherBodyIndex, bool bFromSweep, const FHitResult& SweepResult);

};
