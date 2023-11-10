// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Animation/AnimInstance.h"
#include "AnimCharacter.generated.h"

/**
 * 
 */
UCLASS()
class PROJECTTWO_API UAnimCharacter : public UAnimInstance
{
	GENERATED_BODY()
	
public:
	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "Movement")
	bool bIsWalking;

	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "Movement")
	bool bIsJumping;
};
