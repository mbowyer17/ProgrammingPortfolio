// Fill out your copyright notice in the Description page of Project Settings.


#include "Gun.h"
#include "Kismet/GameplayStatics.h"
#include "Projectile.h"

// Sets default values
AGun::AGun()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	GunMesh = CreateDefaultSubobject<UStaticMeshComponent>(TEXT("GunMesh"));
	SetRootComponent(GunMesh);


	FireSound = nullptr; // Set your fire sound here
	

	bIsShooting = false;

}

// Called when the game starts or when spawned
void AGun::BeginPlay()
{
	Super::BeginPlay();
	
}

// Called every frame
void AGun::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

void AGun::Shoot()
{
	if (ProjectileClass)
	{
		UWorld* World = GetWorld();
		if (World)
		{
			FVector Location;
			FRotator Rotation;

			GetActorEyesViewPoint(Location, Rotation);

			FActorSpawnParameters SpawnParams;
			SpawnParams.SpawnCollisionHandlingOverride = ESpawnActorCollisionHandlingMethod::AlwaysSpawn;

			AActor* Projectile = World->SpawnActor<AActor>(ProjectileClass, Location, Rotation, SpawnParams);

			if (Projectile)
			{
				UGameplayStatics::PlaySoundAtLocation(this, FireSound, GetActorLocation());
			}
		}
	}
}

void AGun::StartShooting()
{
	bIsShooting = true;

	Shoot();
	// Implement shooting logic here
}

void AGun::StopShooting()
{
	bIsShooting = false;
	// Implement logic for stopping shooting here
}

