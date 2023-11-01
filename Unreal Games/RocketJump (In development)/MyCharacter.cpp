// Fill out your copyright notice in the Description page of Project Settings.


#include "MyCharacter.h"
#include "GameFramework/SpringArmComponent.h"
#include "Camera/CameraComponent.h"
#include "RocketProjectile.h"
#include "GameFramework/Actor.h"
#include "GameFramework/CharacterMovementComponent.h"

// Sets default values
AMyCharacter::AMyCharacter()
{
	// Set this character to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
	// Create Components 
	SpringArmComponent = CreateDefaultSubobject<USpringArmComponent>(TEXT("SpringArm"));
	SpringArmComponent->SetupAttachment(RootComponent);
	SpringArmComponent->TargetArmLength = 300.0f;


	// Create Camera
	CameraComponent = CreateDefaultSubobject<UCameraComponent>(TEXT("Camera"));
	CameraComponent->SetupAttachment(SpringArmComponent);

	// Set default air strafe speed
	AirStrafeSpeed = 20.0f;

}



// Called when the game starts or when spawned
void AMyCharacter::BeginPlay()
{
	Super::BeginPlay();

	if (bPressedJump)
	{
		LaunchCharacter(FVector(0.f, 0.f, JumpHeight), false, false);
	}
}

// Called every frame
void AMyCharacter::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

// Called to bind functionality to input
void AMyCharacter::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);

	// Bind the movement input functions
	PlayerInputComponent->BindAxis("MoveForward", this, &AMyCharacter::MoveForward);
	PlayerInputComponent->BindAxis("MoveRight", this, &AMyCharacter::MoveRight);

	// Bind Look inputs functions
	PlayerInputComponent->BindAxis("Turn", this, &AMyCharacter::Turn);
	PlayerInputComponent->BindAxis("LookUp", this, &AMyCharacter::LookUp);

	// Bind Jump
	PlayerInputComponent->BindAction("Jump", IE_Pressed, this, &AMyCharacter::StartJump);
	PlayerInputComponent->BindAction("Jump", IE_Released, this, &AMyCharacter::StopJump);

	// Bind Shooting
	PlayerInputComponent->BindAction("Fire", IE_Pressed, this, &AMyCharacter::Shoot);

}
void AMyCharacter::MoveForward(float Value)
{


	if (Controller != nullptr && Value != 0.f)
	{
		FVector ForwardVector = GetActorForwardVector();

		if (!GetCharacterMovement()->IsMovingOnGround())
		{
			// If in the air, apply the input directly to the character's velocity
			FVector AirVelocity = (ForwardVector * Value * AirStrafeSpeed);
			FVector NewVelocity = GetCharacterMovement()->Velocity + AirVelocity;
			GetCharacterMovement()->Velocity = NewVelocity;
		}
		else
		{
			// If on the ground, use AddMovementInput as before
			AddMovementInput(ForwardVector, Value * MovementSpeed);
		}
	}
}

void AMyCharacter::MoveRight(float Value)
{


	if (Controller != nullptr && Value != 0.f)
	{
		FVector RightVector = GetActorRightVector();
		// Check if the character is in the air
		if (!GetCharacterMovement()->IsMovingOnGround())
		{
			// If in the air, apply the input directly to the character's velocity
			FVector AirVelocity = (RightVector * Value * AirStrafeSpeed);
			FVector NewVelocity = GetCharacterMovement()->Velocity + AirVelocity;
			GetCharacterMovement()->Velocity = NewVelocity;
		}
		else
		{
			// If on the ground, use AddMovementInput as before
			AddMovementInput(RightVector, Value * MovementSpeed);
		}
	}
}

void AMyCharacter::Turn(float Value)
{
	AddControllerYawInput(Value);

}

void AMyCharacter::LookUp(float Value)
{
	AddControllerPitchInput(Value);
}

void AMyCharacter::StartJump()
{
	bPressedJump = true;
}

void AMyCharacter::StopJump()
{
	bPressedJump = false;
}

void AMyCharacter::Shoot()
{

	float CurrentTime = GetWorld()->GetRealTimeSeconds();

	if (CurrentTime >= TimeOfLastShot + ShootCooldown)
	{
		UWorld* World = GetWorld();
		// Get camera's Location and rotation
		FVector CameraLocation;
		FRotator CameraRotation;
		GetActorEyesViewPoint(CameraLocation, CameraRotation);

		// Set the spawn location slighty in front of camera
		FVector MuzzleLocation = CameraLocation + FTransform(CameraRotation).TransformVector(FVector(100.f, 0.f, 0.f));

		// Spawn Projectile
		FActorSpawnParameters SpawnParams;
		SpawnParams.Owner = this;
		SpawnParams.Instigator = GetInstigator();
		ARocketProjectile* Projectile = World->SpawnActor<ARocketProjectile>(ProjectileClass, MuzzleLocation, CameraRotation, SpawnParams);

		TimeOfLastShot = CurrentTime;
	}



}


