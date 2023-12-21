// Fill out your copyright notice in the Description page of Project Settings.


#include "OverheadWidget.h"
#include "Components/TextBlock.h"
#include "GameFramework/PlayerState.h"
#include "GameFramework/PlayerController.h"

void UOverheadWidget::SetDisplayText(FString TextToDisplay)
{
	if (DisplayText)
	{
		DisplayText->SetText(FText::FromString(TextToDisplay));
	}
}

void UOverheadWidget::ShowPlayerNetRole(APawn* InPawn)
{
	FString PlayerName;
	// Check if the InPawn has an associated APlayerController.
	if (InPawn)
	{
		// Get the APlayerState from the APlayerController.
		APlayerController* PlayerController = Cast<APlayerController>(InPawn->GetController());
		if (PlayerController && PlayerController->PlayerState)
		{
			// Call GetPlayerName on the APlayerState to get the player's name.
			PlayerName = PlayerController->PlayerState->GetPlayerName();
		}
	}
	ENetRole RemoteRole = InPawn->GetRemoteRole();

	FString Role;
	switch (RemoteRole)
	{
	case ROLE_None:
		Role = PlayerName;
		break;
	case ROLE_SimulatedProxy:
		Role = PlayerName;
		break;
	case ROLE_AutonomousProxy:
		Role = PlayerName;
		break;
	case ROLE_Authority:
		Role = PlayerName;
		break;
	case ROLE_MAX:
		Role = PlayerName;
		break;
	default:
		break;
	}

	FString RemoteRoleString = FString::Printf(TEXT("%s"), *Role);
	SetDisplayText(RemoteRoleString);

}

void UOverheadWidget::NativeDestruct()
{
	RemoveFromParent();
	Super::NativeDestruct();
}

