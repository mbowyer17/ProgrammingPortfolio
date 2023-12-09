// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Character.h"
#include "Npc_Walk.generated.h"

UCLASS()
class PROJECTTWO_API ANpc_Walk : public ACharacter
{
	GENERATED_BODY()

public:
	// Sets default values for this character's properties
	ANpc_Walk();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

	// Called to bind functionality to input
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Npc")
	float Health;

	void Death();

	virtual float TakeDamage(float DamageAmount, struct FDamageEvent const& DamageEvent, class AController* EventInstigator, AActor* DamageCauser);

	void Shoot();

	
	UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, Category = "Projectile")
	TSubclassOf<class ANpc_Projectile> ProjectileClass;

	// Location to spawn the projectile (e.g., the muzzle of a gun)
	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Npc")
	USceneComponent* MuzzleLocation;

private: 
	// Cooldown time in seconds
	UPROPERTY(EditDefaultsOnly, Category = "Combat")
	float ShootCooldown = 2.0f; // Set this to the desired cooldown duration

	// Timestamp of the last shot
	float LastShotTime = 0.0f;
};
