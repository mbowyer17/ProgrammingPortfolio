// Fill out your copyright notice in the Description page of Project Settings.


#include "AdvancedTPCharacter.h"
#include "GameFramework/SpringArmComponent.h"
#include "Camera/CameraComponent.h"
#include "Animation/AnimInstance.h"
#include "AnimCharacter.h"
#include "UObject/UnrealTypePrivate.h"
#include "UObject/UnrealType.h"


// Sets default values
AAdvancedTPCharacter::AAdvancedTPCharacter()
{
 	// Set this character to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	// Create CameraBoom
	CameraBoom = CreateDefaultSubobject<USpringArmComponent>(TEXT("CameraBoom"));
	CameraBoom->SetupAttachment(RootComponent);
	CameraBoom->TargetArmLength = 300.f;
	CameraBoom->bUsePawnControlRotation = true;

	// Create Camera
	FollowCamera = CreateDefaultSubobject<UCameraComponent>(TEXT("Camera"));
	FollowCamera->SetupAttachment(CameraBoom, USpringArmComponent::SocketName);
	FollowCamera->bUsePawnControlRotation = false;


}

// Called when the game starts or when spawned
void AAdvancedTPCharacter::BeginPlay()
{
	Super::BeginPlay();

	if (MyAnimBlueprintClass)
	{
		GetMesh()->SetAnimInstanceClass(MyAnimBlueprintClass);
	
	}

	
}

// Called every frame
void AAdvancedTPCharacter::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

	CheckMovementState();

	
	//GEngine->AddOnScreenDebugMessage(-1, 5.f, FColor::Yellow, FString::Printf(TEXT("bIsWalking: %s"), bIsWalking ? TEXT("True") : TEXT("False")));
}

// Called to bind functionality to input
void AAdvancedTPCharacter::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);

	// Setup Input 
	PlayerInputComponent->BindAxis("MoveForward", this, &AAdvancedTPCharacter::MoveForward);
	PlayerInputComponent->BindAxis("MoveRight", this, &AAdvancedTPCharacter::MoveRight);
	PlayerInputComponent->BindAction("Jump", IE_Pressed, this, &AAdvancedTPCharacter::StartJump);
	PlayerInputComponent->BindAction("Jump", IE_Released, this, &AAdvancedTPCharacter::StopJump);

	PlayerInputComponent->BindAxis("Turn", this, &AAdvancedTPCharacter::Turn);
	PlayerInputComponent->BindAxis("LookUp", this, &AAdvancedTPCharacter::LookUp);

	PlayerInputComponent->BindAction("Shoot", IE_Pressed, this, &AAdvancedTPCharacter::Shoot);

}

void AAdvancedTPCharacter::MoveForward(float Value)
{
	AddMovementInput(GetActorForwardVector(), Value);
}

void AAdvancedTPCharacter::MoveRight(float Value)
{
	AddMovementInput(GetActorRightVector(), Value);
}

void AAdvancedTPCharacter::StartJump()
{

	bIsJumping = true;
	bPressedJump = true;
}

void AAdvancedTPCharacter::StopJump()
{
	bIsJumping = false;
	bPressedJump = false;
}

void AAdvancedTPCharacter::Turn(float Value)
{
	AddControllerYawInput(Value);
}

void AAdvancedTPCharacter::LookUp(float Value)
{
	AddControllerPitchInput(Value);
}

void AAdvancedTPCharacter::CheckMovementState()
{
	bIsWalking = GetVelocity().Size() > 1.f;

}

void AAdvancedTPCharacter::Shoot()
{
	if (ProjectileBlueprint)
	{
		FVector SpawnLocation = GetMesh()->GetSocketLocation("ShootSocket");
		FRotator SpawnRotation = GetActorRotation(); // Uses the character's rotation.

		// Spawns the projectile in the world.
		GetWorld()->SpawnActor<AActor>(ProjectileBlueprint, SpawnLocation, SpawnRotation);
	}
}


