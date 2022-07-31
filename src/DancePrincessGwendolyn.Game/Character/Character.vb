Public Class Character
    Public ReadOnly Id As Long
    Public Sub New(characterId As Long)
        Id = characterId
    End Sub

    Public Sub RestoreConfidence()
        SetStatistic(CharacterStatisticType.Anxiety, 0)
    End Sub

    Public Function Recover() As (Boolean, DanceStyle)
        If Not CanRecover Then
            Return (False, DanceStyle.None)
        End If
        AddEnnui(1)
        Dim confidenceRestored As Boolean = Confidence < MaximumConfidence
        If confidenceRestored Then
            SetStatistic(CharacterStatisticType.Anxiety, GetStatistic(CharacterStatisticType.Anxiety).Value \ 2)
        End If
        Dim style = DanceStyle.None
        Dim danceStyles = AllDanceStyles.Where(Function(x) RemainingUses(x) < TotalUses(x))
        If danceStyles.Any Then
            style = RNG.FromEnumerable(danceStyles)
            SetStatistic(style.UsageStatisticType, GetStatistic(style.UsageStatisticType).Value \ 2)
        End If
        Return (confidenceRestored, style)
    End Function

    Public ReadOnly Property CanWin As Boolean
        Get
            Return EquipSlots.Any(Function(x) x.Value.CanWin)
        End Get
    End Property

    Public Sub Unequip(equipSlot As EquipSlot)
        Dim item As Item = Nothing
        If EquipSlots.TryGetValue(equipSlot, item) Then
            EquipSlotItemData.ClearForItem(item.Id)
            Inventory.Add(item)
        End If
    End Sub

    Public Sub Equip(item As Item)
        If CanEquip(item) Then
            InventoryItemData.ClearForItem(item.Id)
            EquipSlotItemData.Write(Id, item.EquipSlot, item.Id)
        End If
    End Sub

    Public ReadOnly Property EquipSlots As IReadOnlyDictionary(Of EquipSlot, Item)
        Get
            Return EquipSlotItemData.ReadForCharacter(Id).
                ToDictionary(
                    Function(x) CType(x.Item1, EquipSlot),
                    Function(x) Item.FromId(x.Item2))
        End Get
    End Property

    Public ReadOnly Property HasEquipment As Boolean
        Get
            Return EquipSlots.Any
        End Get
    End Property

    Public Function CanEquip(item As Item) As Boolean
        Return item.CanEquip()
    End Function

    Public Function Use(item As Item) As String
        If Not CanUse(item) Then
            Return $"{Name} cannot use {item.Name} at this time!"
        End If
        Return item.Use(Me)
    End Function

    Public Function CanUse(item As Item) As Boolean
        Return item.CanUse
    End Function

    Public Sub PickUp(item As Item)
        Inventory.Add(item)
    End Sub

    Public Sub Drop(item As Item)
        Location.Inventory.Add(item)
    End Sub

    Public ReadOnly Property HasInventory As Boolean
        Get
            Return Not Inventory.IsEmpty
        End Get
    End Property

    Public Function CanBuy(itemType As ItemType) As Boolean
        Return Bux >= itemType.Price
    End Function

    Public Sub Buy(itemType As ItemType)
        If CanBuy(itemType) Then
            AddBux(-itemType.Price)
            Inventory.Add(Item.Create(itemType))
        End If
    End Sub

    Public ReadOnly Property Inventory As Inventory
        Get
            Dim inventoryId As Long? = InventoryData.ReadForCharacter(Id)
            If Not inventoryId.HasValue Then
                inventoryId = InventoryData.CreateForCharacter(Id)
            End If
            Return Inventory.FromId(inventoryId)
        End Get
    End Property

    Public Sub BuyIceCream()
        If CanBuyIceCream Then
            RestoreEnthusiasm()
            AddBux(-1)
        End If
    End Sub

    Public Sub RestoreEnthusiasm()
        SetStatistic(CharacterStatisticType.Ennui, 0)
    End Sub

    Public Sub TrainConfidence()
        If CanTrainConfidence Then
            AddSparkle(-ConfidenceTrainingCost)
            AddConfidence(1)
        End If
    End Sub

    Public Sub TrainEnthusiasm()
        If CanTrainEnthusiasm Then
            AddSparkle(-EnthusiasmTrainingCost)
            AddEnthusiasm(1)
        End If
    End Sub

    Public Sub TrainDanceStyleSkill(danceStyle As DanceStyle)
        If CanTrainDanceStyle(danceStyle) Then
            AddSparkle(-DanceStyleTrainingCost(danceStyle))
            SetStatistic(danceStyle.CharacterStatisticType, GetStatistic(danceStyle.CharacterStatisticType).Value + 1)
        End If
    End Sub

    Public ReadOnly Property CanBuyIceCream() As Boolean
        Get
            Return Enthusiasm < MaximumEnthusiasm AndAlso Location.CanBuyIceCream AndAlso Bux > 0
        End Get
    End Property

    Public Sub TrainDanceStyleUse(danceStyle As DanceStyle)
        If CanTrainDanceStyle(danceStyle) Then
            AddSparkle(-DanceStyleTrainingCost(danceStyle))
            SetStatistic(danceStyle.MaximumUsageStatisticType, GetStatistic(danceStyle.MaximumUsageStatisticType).Value + 1)
        End If
    End Sub

    Private Sub AddConfidence(delta As Long)
        ChangeStatistic(CharacterStatisticType.Confidence, delta)
    End Sub

    Private Sub AddEnthusiasm(delta As Long)
        ChangeStatistic(CharacterStatisticType.Enthusiasm, delta)
    End Sub

    Private Sub AddEnnui(delta As Long)
        ChangeStatistic(CharacterStatisticType.Ennui, delta)
    End Sub

    Public Property Location As Location
        Get
            Return Location.FromId(CharacterData.ReadLocation(Id))
        End Get
        Set(value As Location)
            If value.Id <> CharacterData.ReadLocation(Id).Value Then
                value.Refresh()
                CharacterData.WriteLocation(Id, value.Id)
            End If
        End Set
    End Property

    Private Const ConfidenceTrainingMultiplier As Long = 10
    Private Const EnthusiasmTrainingMultiplier As Long = 20

    Public ReadOnly Property CanTrainConfidence As Boolean
        Get
            Return Sparkle >= ConfidenceTrainingCost
        End Get
    End Property

    Public ReadOnly Property CanTrainEnthusiasm As Boolean
        Get
            Return Sparkle >= EnthusiasmTrainingCost
        End Get
    End Property

    Public ReadOnly Property CanTrainDanceStyle(danceStyle As DanceStyle) As Boolean
        Get
            Return Sparkle >= DanceStyleTrainingCost(danceStyle)
        End Get
    End Property

    Public ReadOnly Property ConfidenceTrainingCost As Long
        Get
            Return MaximumConfidence * ConfidenceTrainingMultiplier
        End Get
    End Property

    Public ReadOnly Property EnthusiasmTrainingCost As Long
        Get
            Return MaximumEnthusiasm * EnthusiasmTrainingMultiplier
        End Get
    End Property

    Public ReadOnly Property DanceStyleTrainingCost(danceStyle As DanceStyle) As Long
        Get
            Return GetStatistic(danceStyle.CharacterStatisticType).Value * GetStatistic(danceStyle.MaximumUsageStatisticType).Value
        End Get
    End Property

    Public Sub AddSparkle(delta As Long)
        SetStatistic(CharacterStatisticType.Sparkle, GetStatistic(CharacterStatisticType.Sparkle).Value + delta)
    End Sub

    Public Sub AddBux(delta As Long)
        SetStatistic(CharacterStatisticType.Bux, GetStatistic(CharacterStatisticType.Bux).Value + delta)
    End Sub

    Public Function RollDefeatBux() As Long
        Return CharacterType.RollDefeatBux(Me)
    End Function

    Public Sub RestoreUses(danceStyle As DanceStyle)
        SetStatistic(danceStyle.UsageStatisticType, 0)
    End Sub

    Public Function PickRandomDanceStyle() As DanceStyle
        Dim table As New Dictionary(Of DanceStyle, Integer)
        For Each danceStyle In AllDanceStyles
            Dim uses = RemainingUses(danceStyle)
            If uses > 0 Then
                table(danceStyle) = CInt(uses)
            End If
        Next
        If Not table.Any Then
            Return DanceStyle.None
        End If
        Return RNG.FromGenerator(table)
    End Function

    Public ReadOnly Property CanRecover As Boolean
        Get
            Return Enthusiasm > 0 AndAlso (Confidence < MaximumConfidence OrElse AllDanceStyles.Any(Function(x) GetStatistic(x.UsageStatisticType).Value > 0))
        End Get
    End Property

    Public ReadOnly Property CanDoDanceOff As Boolean
        Get
            Return Confidence > 0 AndAlso Location.NonPlayerCharacters.Any
        End Get
    End Property

    Public ReadOnly Property CanVisitLifeCoach As Boolean
        Get
            Return Confidence < 1 AndAlso Location.HasLifeCoach
        End Get
    End Property

    Public Shared Function FromId(characterId As Long?) As Character
        If Not characterId.HasValue Then
            Return Nothing
        End If
        Return New Character(characterId.Value)
    End Function
    Public Shared Function Create(characterType As CharacterType, location As Location) As Character
        Dim character = FromId(CharacterData.Create(characterType, location.Id))
        characterType.OnCreate(character)
        Return character
    End Function

    Public Sub AddAnxiety(delta As Long)
        ChangeStatistic(CharacterStatisticType.Anxiety, delta)
    End Sub

    Public ReadOnly Property CharacterType As CharacterType
        Get
            Return CType(CharacterData.ReadCharacterType(Id).Value, CharacterType)
        End Get
    End Property

    Public Sub Destroy()
        CharacterData.Clear(Id)
    End Sub

    Public ReadOnly Property Name As String
        Get
            Return CharacterType.Name
        End Get
    End Property

    Private ReadOnly Property Anxiety As Long
        Get
            Return GetStatistic(CharacterStatisticType.Anxiety).Value
        End Get
    End Property

    Public ReadOnly Property Confidence As Long
        Get
            Return Math.Min(Math.Max(0, MaximumConfidence - Anxiety), MaximumConfidence)
        End Get
    End Property

    Public ReadOnly Property Bux As Long
        Get
            Return GetStatistic(CharacterStatisticType.Bux).Value
        End Get
    End Property

    Public ReadOnly Property Sparkle As Long
        Get
            Return GetStatistic(CharacterStatisticType.Sparkle).Value
        End Get
    End Property

    Public ReadOnly Property MaximumConfidence As Long
        Get
            Return GetStatistic(CharacterStatisticType.Confidence).Value
        End Get
    End Property

    Private ReadOnly Property Ennui As Long
        Get
            Return GetStatistic(CharacterStatisticType.Ennui).Value
        End Get
    End Property

    Public Sub AddUse(danceStyle As DanceStyle)
        ChangeStatistic(danceStyle.UsageStatisticType, 1)
    End Sub

    Public ReadOnly Property Enthusiasm As Long
        Get
            Return Math.Min(Math.Max(0, MaximumEnthusiasm - Ennui), MaximumEnthusiasm)
        End Get
    End Property

    Public ReadOnly Property MaximumEnthusiasm As Long
        Get
            Return GetStatistic(CharacterStatisticType.Enthusiasm).Value
        End Get
    End Property

    Public Function GetStatistic(statisticType As CharacterStatisticType) As Long?
        Return CharacterStatisticData.Read(Id, statisticType)
    End Function

    Public Function GetStatisticBuff(statisticType As CharacterStatisticType) As Long
        Return EquipSlots.Values.Sum(Function(x) If(x.GetBuff(statisticType), 0))
    End Function

    Private Sub ChangeStatistic(statisticType As CharacterStatisticType, delta As Long)
        SetStatistic(statisticType, GetStatistic(statisticType).Value + delta)
    End Sub

    Private Sub SetStatistic(statisticType As CharacterStatisticType, value As Long)
        Dim minimum = statisticType.Minimum(Me)
        Dim maximum = statisticType.Maximum(Me)
        value = Math.Max(Math.Min(value, maximum), minimum)
        CharacterStatisticData.Write(Id, statisticType, value)
    End Sub

    Public ReadOnly Property DanceSkills As IReadOnlyDictionary(Of DanceStyle, Long)
        Get
            Return AllDanceStyles.ToDictionary(
                Function(x) x,
                Function(x) GetStatistic(x.CharacterStatisticType).Value)
        End Get
    End Property

    Private Function UsageCount(danceStyle As DanceStyle) As Long
        Return GetStatistic(danceStyle.UsageStatisticType).Value
    End Function

    Public Function RemainingUses(danceStyle As DanceStyle) As Long
        Return Math.Min(Math.Max(0, TotalUses(danceStyle) - UsageCount(danceStyle)), TotalUses(danceStyle))
    End Function

    Public Function TotalUses(danceStyle As DanceStyle) As Long
        Return GetStatistic(danceStyle.MaximumUsageStatisticType).Value
    End Function

    Public ReadOnly Property IsPlayer As Boolean
        Get
            Return Id = World.PlayerCharacter.Id
        End Get
    End Property

    Public ReadOnly Property CanShop As Boolean
        Get
            Return Location.HasShoppe
        End Get
    End Property
End Class
