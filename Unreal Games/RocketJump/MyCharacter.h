// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Character.h"
#include "MyCharacter.generated.h"

// Declare Classes
class UCameraComponent;
class USpringArmComponent;

UCLASS()
class PORTFOLIOWORKS_API AMyCharacter : public ACharacter
{
	GENERATED_BODY()

public:
	// Sets default values for this character's properties
	AMyCharacter();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;


	float ShootCooldown = 0.5f;
	float TimeOfLastShot = 0.f;

public:
	// Called every frame
	virtual void Tick(float DeltaTime) override;

	// Called to bind functionality to input
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;

	// Access to BluePrints
	UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = "Camera")
	USpringArmComponent* SpringArmComponent;

	UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = "Camera")
	UCameraComponent* CameraComponent;

	// Declaring functions
	UFUNCTION()
	void MoveForward(float Value);

	UFUNCTION()
	void MoveRight(float Value);

	UFUNCTION()
	void Turn(float Value);

	UFUNCTION()
	void LookUp(float Value);

	UFUNCTION()
	void StartJump();

	UFUNCTION()
	void StopJump();

	UFUNCTION()
	void Shoot();

	UPROPERTY(EditDefaultsOnly, Category = "Character")
	TSubclassOf<class ARocketProjectile> ProjectileClass;

	UPROPERTY(EditDefaultsOnly, BluePrintReadOnly, Category = "Character")
	float JumpHeight = 300.f;

	// Air strafe speed while in air
	UPROPERTY(EditAnywhere, Category = "Character")
	float AirStrafeSpeed;

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Movement")
	float MovementSpeed = 600.0f;

};