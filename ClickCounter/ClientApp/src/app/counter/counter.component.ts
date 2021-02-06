import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public currentCount = 0;

    baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    http.get<number>(baseUrl + 'api/click/count').subscribe(result => {
      this.currentCount = result;
    });

    setInterval(() => {
      http.get<number>(baseUrl + 'api/click/count').subscribe(result => {
        this.currentCount = result;
      });
    }, 1000);
  }

  public incrementCounter() {
    this.currentCount++;
    this.http.get<number>(this.baseUrl + 'api/click/countup').subscribe(result => { });
  }
}
