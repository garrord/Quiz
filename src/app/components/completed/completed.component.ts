import { Component, Input } from "@angular/core";

@Component({
    selector: 'completed-component',
    templateUrl: 'completed.component.html'
})

export class CompletedComponent{
    @Input() percentage: number = 0;
}