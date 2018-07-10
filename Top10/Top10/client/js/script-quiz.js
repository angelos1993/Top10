var globalTimer;

function startGame() {
    $("#divStartGame").addClass("d-none");
    $("#hfCurrentQuestion").val(1);
    $("#divQuestion1").removeClass("d-none");
    $("#divButtons").removeClass("d-none");
    $("html, body").animate({
            scrollTop: $("[id$=DivNewQuiz]").offset().top
        },
        1000);
    $("#spnTimer").text($("[id$=HfTimer]").val());
    setTimer();
}

function setTimer() {
    var timerString = $("[id$=HfTimer]").val();
    if (timerString == null || timerString === "")
        timerString = "90";
    globalTimer = parseInt(timerString);
    $(".timer-div").removeClass("d-none");
    setInterval(() => {
            globalTimer = globalTimer - 1;
            $("#spnTimer").text(globalTimer);
            if (globalTimer !== 90 && globalTimer % 5 === 0) {
                $.ajax({
                    type: "POST",
                    url: "Quiz.aspx/SetTime",
                    data: JSON.stringify({ "timeLapsed": 90 - globalTimer }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json"
                });
            }
            if (globalTimer <= 40 && $(".timer-div").hasClass("btn-success")) {
                $(".timer-div").removeClass("btn-success").addClass("btn-warning");
            }
            if (globalTimer <= 10 && $(".timer-div").hasClass("btn-warning")) {
                $(".timer-div").removeClass("btn-warning").addClass("btn-danger");
                $(".timer-div").addClass("infinite").addClass("animated").addClass("shake");
            }
            if (globalTimer <= 0) {
                $("[id$=BtnSubmitAnswers]").click();
            }
        },
        1000);
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