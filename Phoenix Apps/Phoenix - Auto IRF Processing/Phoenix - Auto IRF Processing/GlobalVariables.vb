Module GlobalVariables

    Friend Const FileDirectory As String = "Z:\IRF\No Change\"

    Friend CaseNumber As String
    Friend BatchNumber As String
    Friend LastBatchNumber As String
    Friend isSuccessful As Boolean
    Friend CaseMessage As String

    Friend FAMISCaseInformation As CaseInformation
    Friend FAMISApplicationInformation As ApplicationInformation
    Friend FAMISIndividualsInformation As IndividualsInformation
    Friend FAMISMedicaidInformation As MedicaidInformation
    Friend FAMISTANFInformation As TANFInformation
    Friend FAMISIncomeInformation As IncomeInformation
    Friend FAMISFoodStampInformation As FoodStampInformation
    Friend FAMISIandAInformation As IandAInformation
    Friend FAMISCaseChild(35) As CaseChild
    Friend CaseChildCount As Integer

End Module
