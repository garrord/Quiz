import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { QuestionModel } from "../models/questionModel";

@Injectable()
export class QuestionsService{
    private readonly questionUrl = 'http://localhost:5026/api/question';

    constructor(protected http: HttpClient){}

    public GetQuestionsByCategoryName(category: string) : Observable<QuestionModel[]>{
        return this.http.get<QuestionModel[]>(`${this.questionUrl}/${category}`);
    }
}