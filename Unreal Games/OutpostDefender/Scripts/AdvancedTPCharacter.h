// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Character.h"
#include "AdvancedTPCharacter.generated.h"

UCLASS()
class PROJECTTWO_API AAdvancedTPCharacter : public ACharacter
{
	GENERATED_BODY()

public:
	// Sets default values for this character's properties
	AAdvancedTPCharacter();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

	// Components
	UPROPERTY(VisibleAnyWhere, BlueprintReadOnly, Category = "Camera")
	class USpringArmComponent* CameraBoom;

	UPROPERTY(VisibleAnyWhere, BlueprintReadOnly, Category = "Camera")
	class UCameraComponent* FollowCamera;


public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

	// Called to bind functionality to input
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;

	// Movement Function
	void MoveForward(float Value);
	void MoveRight(float Value);
	void StartJump();
	void StopJump();

	// Camera Functions
	void Turn(float Value);
	void LookUp(float Value);

	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "Movement")
	bool bIsWalking;

	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "Movement")
	bool bIsJumping;

	// Check character's movement state and update animations
	void CheckMovementState();

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "ZAnimation")
	class TSubclassOf<UAnimInstance> MyAnimBlueprintClass;

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "ZAnimation")
	class UAnimInstance* MyAnimInstance;

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Projectile")
	TSubclassOf<class AActor> ProjectileBlueprint;

	void Shoot();
	
};
