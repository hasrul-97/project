import { Injectable } from '@angular/core';
import { BehaviorSubject } from '../../../../node_modules/rxjs';

@Injectable({
  providedIn: 'root'
})
export class SearchService {
private messageSource=new BehaviorSubject('');
currentmessage=this.messageSource.asObservable();
  constructor() { }
  changeMessage(messages :string)
  {
    this.messageSource.next(messages)
    console.log(this.currentmessage.subscribe());

  }
}
