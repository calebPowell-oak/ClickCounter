import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent implements OnInit {
  public currentCount = 0;
  public challengeWord = '';
  public challengeTail = '';
  public human = false;
  public guid = '12-12-12-12';
  public answerInput: HTMLInputElement;

  baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    const headers = new HttpHeaders().set('Content-Type', 'text/plain; charset=utf-8');

    this.getNewQuiz();

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

  ngOnInit(): void {
    this.answerInput = <HTMLInputElement>document.getElementById('answer');
  }

  public getNewQuiz() {
    this.http.get(this.baseUrl + 'api/quiz/get', { responseType: 'text' }).subscribe(result => {
      this.challengeWord = result.split(',')[0];
      this.challengeTail = result.split(',')[1];
    });
  }

  public incrementCounter() {
    this.currentCount++;
    this.http.get<number>(this.baseUrl + 'api/click/countup', { headers: { 'Session-Guid': this.guid } }).subscribe(res => { }, error => {
      this.getNewQuiz();
      this.human = false;
    });
  }

  public answerQuiz() {
    let quizAnswer = `${this.answerInput.value},${this.challengeTail}`;
    this.http.get<string>(this.baseUrl + `api/quiz/submit?answer=${quizAnswer}`).subscribe(result => {
      this.guid = result;
      this.answerInput.value = '';
      this.human = true;
    });
  }
}
