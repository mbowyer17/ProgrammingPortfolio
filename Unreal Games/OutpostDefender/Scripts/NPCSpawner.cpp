// Fill out your copyright notice in the Description page of Project Settings.


#include "NPCSpawner.h"
#include "Kismet/GameplayStatics.h"


// Sets default values
ANPCSpawner::ANPCSpawner()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

}

// Called when the game starts or when spawned
void ANPCSpawner::BeginPlay()
{
	Super::BeginPlay();
	
    // Use a TActorIterator<AActor> to find the actor called BP_SafeHouse
    UGameplayStatics::GetAllActorsWithTag(GetWorld(), FName("OutpostTag"), FoundActors);

    // If there is at least one actor with the 'SafehouseTag' tag
    if (FoundActors.Num() > 0)
    {
        // Assume the first found actor is the one you want
        OutpostActor = FoundActors[0];
        UE_LOG(LogTemp, Warning, TEXT("Outpost actor assigned."));
    }
    else
    {
        UE_LOG(LogTemp, Error, TEXT("No Safehouse actor found with the specified tag."));
    }
    // Start the spawning process

     // Set up the timer to call SpawnNPCsAroundSafehouse every 2 seconds
    GetWorldTimerManager().SetTimer(SpawnTimerHandle, this, &ANPCSpawner::SpawnNpcsAroundOutpost, 2.0f, true);
    
}

// Called every frame
void ANPCSpawner::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
  
}

// Note to spawn around an actor you must use polar coordinates
void ANPCSpawner::SpawnNpcsAroundOutpost()
{
    // Check if they are valid
    if (OutpostActor && NPCClass)
    {

        // Define the radius of the circle around the outpost where NPCs will spawn
        float SpawnRadius = 3000.0f; // NPCs will spawn within 500 units of the safe house

        // Random angle in radians
        float RandomAngleRad = FMath::RandRange(0.f, 2.0f * PI);

        // Convert polar coordinates to Cartesian
        FVector RelativeOffset = FVector(
            FMath::Cos(RandomAngleRad) * SpawnRadius, // X coordinate
            FMath::Sin(RandomAngleRad) * SpawnRadius, // Y coordinate
            50.0f); // Z coordinate 
       
        // Grab Location
        FVector SpawnLocation = OutpostActor->GetActorLocation() + RelativeOffset;

        // We're creating a vector from the NPC to the Outpost, then getting the rotation for that vector
        FVector Direction = OutpostActor->GetActorLocation() - SpawnLocation;
        FRotator SpawnRotation = Direction.Rotation();

        // Spawn param
        FActorSpawnParameters SpawnParams;
        SpawnParams.Owner = this;
        SpawnParams.Instigator = GetInstigator();

        // Actually spawn the NPC
        AActor* SpawnedNPC = GetWorld()->SpawnActor<AActor>(NPCClass, SpawnLocation, SpawnRotation, SpawnParams);
        UE_LOG(LogTemp, Error, TEXT("sssssssssssssssssssssssssssssssssssssss"));

    }
}

