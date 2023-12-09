// Fill out your copyright notice in the Description page of Project Settings.


#include "Npc_WalkAi.h"
#include "NavigationSystem.h"
#include "Blueprint/AIBlueprintHelperLibrary.h"
#include "GameFramework/Character.h"
#include "GameFramework/CharacterMovementComponent.h"
#include "Kismet/GameplayStatics.h"
#include "Engine.h"
#include "Npc_Walk.h"


ANpc_WalkAi::ANpc_WalkAi()
{
	// Set this AI controller to receive tick events every frame
	PrimaryActorTick.bCanEverTick = true;

	// Initialize move speed (units per second)
	MoveSpeed = 600.f; // Default value, can be changed in editor or at runtime

    // Adjust this setting for stopping distance  
    StoppingDistance = 2000.f;

}

void ANpc_WalkAi::BeginPlay()
{
    Super::BeginPlay();

    // Use a TActorIterator<AActor> to find the actor called BP_SafeHouse
    UGameplayStatics::GetAllActorsWithTag(GetWorld(), FName("OutpostTag"), FoundActors);

    // If there is at least one actor with the 'SafehouseTag' tag
    if (FoundActors.Num() > 0)
    {
        // Assume the first found actor is the one you want
        TargetActor = FoundActors[0];
        UE_LOG(LogTemp, Warning, TEXT("Safehouse actor assigned."));
    }
    else
    {
        UE_LOG(LogTemp, Error, TEXT("No Safehouse actor found with the specified tag."));
    }
}

void ANpc_WalkAi::Tick(float DeltaTime)
{
    Super::Tick(DeltaTime);

    //UE_LOG(LogTemp, Warning, TEXT("Tick is being called."));

    ACharacter* MyCharacter = Cast<ACharacter>(GetPawn());
    // Checks if both pawn and the target actor are valid
    if (MyCharacter && TargetActor)
    {
        // Get the bounding box of the target actor
        FVector TargetActorCenter, TargetActorExtents;
        TargetActor->GetActorBounds(false, TargetActorCenter, TargetActorExtents);

        // Calculate the vector distance between AI and the center of the target actor's bounding box
        FVector Delta = TargetActorCenter - MyCharacter->GetActorLocation();
        float DistanceToTarget = Delta.Size();

        if (DistanceToTarget > StoppingDistance)
        {
            // Move towards the target actor
            UAIBlueprintHelperLibrary::SimpleMoveToLocation(this, TargetActorCenter);

            // Calculate the direction to the target actor's center
            FVector DirectionToTarget = Delta.GetSafeNormal();
            FRotator NewRotation = FRotationMatrix::MakeFromX(DirectionToTarget).Rotator();
            MyCharacter->SetActorRotation(NewRotation);

            //UE_LOG(LogTemp, Warning, TEXT("Moving towards target."));
        }
        else
        {
            // Stop moving if within stopping distance
            MyCharacter->GetCharacterMovement()->StopMovementImmediately();
      

            // Now grab the npc Shoot function
            ANpc_Walk* MyNpc = Cast<ANpc_Walk>(MyCharacter);

            if (MyNpc)
            {
                MyNpc->Shoot();
            }
        }
    }
}
