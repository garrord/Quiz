import { Component, EventEmitter, Input, Output } from "@angular/core";
import { AnswerModel } from "src/app/models/answerModel";

@Component({
    selector: 'questions-component',
    templateUrl: 'questions.component.html',
    styleUrls: ['questions.component.scss']
})

export class QuestionsComponent{
    isSelected:boolean = false;
    selectedAnswer: boolean = false;

    @Input() question: string = "";
    @Input() answers: AnswerModel[] = [];
    @Input() isLastQuestion: boolean = false;
    @Output() next: EventEmitter<boolean> = new EventEmitter<boolean>();
    @Output() isCompleted: EventEmitter<boolean> = new EventEmitter<boolean>();

    nextQuestion(): void{
        this.isSelected = false;
        this.next.emit(this.selectedAnswer);
    }

    selected(selectedAnswer: boolean): void{
        this.isSelected = true;
        this.selectedAnswer = selectedAnswer;
    }

    submitTest(){
        let isCompleted: boolean = true;
        this.isCompleted.emit(isCompleted);
    }
}