// Fill out your copyright notice in the Description page of Project Settings.


#include "Npc_Walk.h"

// Sets default values
ANpc_Walk::ANpc_Walk()
{
 	// Set this character to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	Health = 100.f;
}

// Called when the game starts or when spawned
void ANpc_Walk::BeginPlay()
{
	Super::BeginPlay();
	
}

// Called every frame
void ANpc_Walk::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

// Called to bind functionality to input
void ANpc_Walk::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);

}

