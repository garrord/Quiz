import { Component, OnInit } from "@angular/core";
import { QuestionsService } from '../../services/questions.service'
import { QuestionModel } from "src/app/models/questionModel";
import { ActivatedRoute, Router } from "@angular/router";
import { AnswerModel } from "src/app/models/answerModel";

@Component({
    selector: 'questions-container',
    templateUrl: 'questions.container.html'
})

export class QuestionsContainer implements OnInit{

    constructor(
        private questionsService: QuestionsService,
        private route: ActivatedRoute,
        private router: Router){}

    isLastQuestion: boolean = false;
    isCompleted: boolean = false;
    questions: QuestionModel[] = [];
    questionNumber: number = 0;
    question: string = "";
    answers: AnswerModel[] = [];
    selectedAnswers: boolean[] = [];
    percentage: number = 0;

    ngOnInit(): void {
        let category = this.route.snapshot.paramMap.get('category')!;
        this.questionsService.GetQuestionsByCategoryName(category).subscribe({
            next: (question) => this.questions = question,
            complete: () => this.displayQuestion()
        });
    }

    displayQuestion(): void{
        this.question = this.questions[this.questionNumber].conundrum;
        this.answers = this.questions[this.questionNumber].answers;
    }

    nextQuestion(selectedAnswer: boolean):void{
        this.selectedAnswers.push(selectedAnswer);
        this.questionNumber += 1;
        
        if (this.questionNumber == this.questions.length){
            this.percentCorrect();
            this.isCompleted = true;
        }
        else {
            if (this.questionNumber == this.questions.length - 1){
                this.isLastQuestion = true;
            }
            this.displayQuestion();
        }
    }

    percentCorrect(): void{
        let correct = 0;
        this.selectedAnswers.forEach(x =>{
            if (x){
                correct += 1;
            }
        })
        this.percentage = (correct / this.questions.length) * 100;
        Number(this.percentage.toFixed(2));
    }
}