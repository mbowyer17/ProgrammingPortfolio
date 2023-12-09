// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "Npc_Projectile.generated.h"

UCLASS()
class PROJECTTWO_API ANpc_Projectile : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	ANpc_Projectile();


protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

	// Function to  initalise the projectile's velocity
	void InitVelocity(const FVector& ShootDirection);

	// Projectile Movement component
	UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = "Movement")
	class UProjectileMovementComponent* ProjectileMovement;

	// Collision
	UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = "Collision")
	class USphereComponent* CollisionComponent;
	
	// Mesh for the projectile
	//UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = "Components")
	//class UStaticMeshComponent* ProjectileMesh;

	// Function to find the target actor by name
	AActor* FindTargetActorByName(FName TargetTag);

	UPROPERTY(VisibleAnywhere, Category = "TargetArray")
	TArray<AActor*> FoundActors;

	UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, Category = "TargetArray")
	AActor* TargetActor;

	UFUNCTION()
	void OnHit(UPrimitiveComponent* HitComponent, AActor* OtherActor, UPrimitiveComponent* OtherComp, FVector NormalImpulse, const FHitResult& Hit);
};
