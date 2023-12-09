// Fill out your copyright notice in the Description page of Project Settings.


#include "SafeHouse.h"

// Sets default values
ASafeHouse::ASafeHouse()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

}

// Called when the game starts or when spawned
void ASafeHouse::BeginPlay()
{
	Super::BeginPlay();
	
	Tags.Add("SafehouseTag");
}

// Called every frame
void ASafeHouse::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

