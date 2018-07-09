function startGame() {
    $("#divStartGame").addClass("d-none");
    $("#hfCurrentQuestion").val(1);
    $("#divQuestion1").removeClass("d-none");
    $("#divButtons").removeClass("d-none");
    setTimer();
}

function setTimer() {
    var timerString = $("[id$=HfTimer]").val();
    if (timerString == null || timerString === "")
        timerString = "90";
    var timer = parseInt(timerString);
    //TODO: need to start the timer
}

function showNextOrPreviousQuestion(mode) {
    var currentQuestionElm = $("#hfCurrentQuestion");
    var currentQuestionNo = parseInt($("#hfCurrentQuestion").val());
    if (mode === "N") {
        currentQuestionNo = currentQuestionNo + 1;
        if (currentQuestionNo > 3)
            currentQuestionNo = 1;
    } else {
        currentQuestionNo = currentQuestionNo - 1;
        if (currentQuestionNo < 1)
            currentQuestionNo = 3;
    }
    currentQuestionElm.val(currentQuestionNo);
    hideAllQuestions();
    $("#divQuestion" + currentQuestionNo).removeClass("d-none");
}

function hideAllQuestions() {
    $("#divQuestion1").addClass("d-none");
    $("#divQuestion2").addClass("d-none");
    $("#divQuestion3").addClass("d-none");
}

function choose(sender) {
    var questionId = $(sender).data("question");
    var allAnswers = $(sender).parent().find("[data-question='" + questionId + "']");
    allAnswers.removeClass("btn-info");
    allAnswers.addClass("btn-outline-info");
    $(sender).addClass("btn-info");
    $(sender).removeClass("btn-outline-info");
    $("[id$=HfQuestion" + $("#hfCurrentQuestion").val() + "Answer]").val($(sender).data("answer"));
}