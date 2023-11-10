// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Character.h"
#include "Npc_Walk.generated.h"

UCLASS()
class PROJECTTWO_API ANpc_Walk : public ACharacter
{
	GENERATED_BODY()

public:
	// Sets default values for this character's properties
	ANpc_Walk();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

	// Called to bind functionality to input
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Npc")
	float Health;
};
