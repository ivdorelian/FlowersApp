import { Component } from '@angular/core';

@Component({
    selector: 'app-counter-component',
    templateUrl: './counter.component.html'
})
export class CounterComponent {
    public currentCount: number = 2;

    public name: string = "test"

    public incrementCounter() {
        this.currentCount++;

        this.name = '';
    }
}
