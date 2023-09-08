// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "Gun.generated.h"

UCLASS()
class PORTFOLIOWORK_API AGun : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	AGun();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

	bool bIsShooting;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

	UPROPERTY(VisibleAnywhere, Category = "Components")
	class UStaticMeshComponent* GunMesh;

	// Function on handling Shooting
	UFUNCTION(BlueprintCallable, Category = "Shooting")
	void Shoot();

	UPROPERTY(EditDefaultsOnly, Category = "Shooting")
	TSubclassOf<class AActor> ProjectileClass; // Reference to the Blueprint class

	UPROPERTY(EditDefaultsOnly, Category = "Shooting")
	TSubclassOf<class AActor> GunBluePrint;
	// Socket Name for Spawning projectiles
	UPROPERTY(EditDefaultsOnly, Category = "Shooting")
	FName MuzzleSocketName;

	UPROPERTY(EditDefaultsOnly, Category = "Shooting")
	USoundBase* FireSound;

	
	void StartShooting();
	void StopShooting();

	

};
