import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public currentCount = 0;
  public challengeWord = '';
  public challengeTail = '';
  public human = false;
  public guid = '12-12-12-12';

  baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    const headers = new HttpHeaders().set('Content-Type', 'text/plain; charset=utf-8');

    http.get(baseUrl + 'api/quiz/get', { responseType: 'text' }).subscribe(result => {
      this.challengeWord = result.split(',')[0];
      this.challengeTail = result.split(',')[1];
    });

    this.baseUrl = baseUrl;
    http.get<number>(baseUrl + 'api/click/count').subscribe(result => {
      this.currentCount = result;
    });

    //setInterval(() => {
    //  http.get<number>(baseUrl + 'api/click/count').subscribe(result => {
    //    this.currentCount = result;
    //  });
    //}, 1000);
  }

  public incrementCounter() {
    this.currentCount++;
    this.http.get<number>(this.baseUrl + 'api/click/countup', { headers: { 'Session-Guid': '' } }).subscribe(result => { });
  }

  public answerQuiz() {
    let quizAnswer = `${document.getElementById('answer').value},${this.challengeTail}`;
    console.log(quizAnswer)
    this.http.post<string>(this.baseUrl + 'api/quiz/submit', quizAnswer).subscribe(result => {

    });
  }
}
