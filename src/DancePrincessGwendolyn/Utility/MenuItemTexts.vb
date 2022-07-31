Module MenuItemTexts
    Friend Const AbandonGameText = "Abandon Game"
    Friend Const AddUseText = "Add Use"
    Friend Const BuyIceCreamText = "Buy Ice Cream"
    Friend Const ContinueText = "Continue"
    Friend Const DanceOffText = "DANCE OFF!!"
    Friend Const DropText = "Drop"
    Friend Const EquipText = "Equip"
    Friend Const GameMenuText = "Game Menu"
    Friend Const GearText = "Gear"
    Friend Const GiveUpText = "Give Up!"
    Friend Const GoShoppingText = "Go Shopping!"
    Friend Const GroundText = "Ground"
    Friend Const IncreaseSkillText = "Increase Skill"
    Friend Const InventoryText = "Inventory"
    Friend Const MoveText = "Move..."
    Friend Const NeverMindText = "Never Mind"
    Friend Const NoText = "No"
    Friend Const ProfileText = "Profile"
    Friend Const QuitText = "Quit"
    Friend Const RecoverText = "Recover"
    Friend Const SaveText = "Save..."
    Friend Const StartText = "Start"
    Friend Const UnequipText = "Unequip"
    Friend Const UseText = "Use"
    Friend Const VisitConfidenceTrainerText = "Visit Confidence Trainer"
    Friend Const WinGameText = "WIN THE GAME!"
    Friend ReadOnly VisitDanceStyleTrainerText As IReadOnlyDictionary(Of DanceStyle, String) =
        New Dictionary(Of DanceStyle, String) From
        {
            {DanceStyle.Ballet, "Visit Ballet Trainer"},
            {DanceStyle.Bollywood, "Visit Bollywood Trainer"},
            {DanceStyle.Cheerleading, "Visit Cheerleading Trainer"},
            {DanceStyle.HipHop, "Visit Hip Hop Trainer"},
            {DanceStyle.LineDancing, "Visit Line Dancing Trainer"},
            {DanceStyle.TapDancing, "Visit TapDancing Trainer"}
        }
    Friend Const VisitEnthusiasmTrainerText = "Visit Enthusiasm Trainer"
    Friend Const VisitLifeCoachText = "Visit Life Coach"
    Friend Const YesText = "Yes"
End Module
