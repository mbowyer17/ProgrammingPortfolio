// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "AIController.h"
#include "Npc_WalkAi.generated.h"

/**
 * 
 */
UCLASS()
class PROJECTTWO_API ANpc_WalkAi : public AAIController
{
	GENERATED_BODY()
	
public:
    ANpc_WalkAi();

    // The player character reference
    UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, Category = "AI")
    AActor* TargetActor;

    UPROPERTY(VisibleAnywhere, Category = "AI")
    TArray<AActor*> FoundActors;

    // Stopping distance from the player
    UPROPERTY(EditDefaultsOnly, BlueprintReadOnly, Category = "AI")
    float StoppingDistance;

protected:
    // Called when the game starts or when spawned
    virtual void BeginPlay() override;

    // Called every frame
    virtual void Tick(float DeltaTime) override;

    // Speed at which the NPC moves forward
    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Movement")
    float MoveSpeed;
};

