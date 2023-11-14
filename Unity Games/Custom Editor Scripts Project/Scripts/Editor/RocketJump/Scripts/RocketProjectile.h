// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "RocketProjectile.generated.h"

UCLASS()
class PORTFOLIOWORKS_API ARocketProjectile : public AActor
{
    GENERATED_BODY()

public:
    ARocketProjectile();

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Explosion")
    float ExplosionRadius;

protected:
    UPROPERTY(VisibleAnywhere)
    class UProjectileMovementComponent* ProjectileMovementComponent;

    UPROPERTY(VisibleAnywhere)
    class USphereComponent* CollisionComponent;

    UPROPERTY(EditDefaultsOnly, Category = "Damage")
    float DamageRadius;

    UFUNCTION()
    void OnHit(UPrimitiveComponent* HitComponent, AActor* OtherActor, UPrimitiveComponent* OtherComp, FVector NormalImpulse, const FHitResult& Hit);

    UFUNCTION(BlueprintImplementableEvent, Category = "ZRocket")
    void OnRocketExplode();

    void Explode();

    UFUNCTION(BlueprintCallable, Category = "ZRocket")
    void LaunchPlayer(ACharacter* PlayerCharacter, float LaunchSpeed);

    UPROPERTY(EditAnywhere, Category = "ZRocket")
    float LaunchPower = 1000.f;

};
