import { Component } from '@angular/core';
import {Customer} from './app.model'
import {HttpClient} from  '@angular/common/http'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  customerObj:Customer = new Customer(); //binded with the UI
  constructor(public httpObj:HttpClient){
    //constructor this code run when instance object is created
  }
  customerObjs:Array<Customer> = new Array<Customer>(); //collection
  //adds in memory
  Add(){
    //Homework: Take current object and add to arraylist collection
    //then in UI, use NGForOf loop
    this.customerObjs.push(this.customerObj); //add the current customer object
    this.customerObj = new Customer();//this will clear the screen
    alert("add is called");
  }
  AddtoServer(){
    //we need to make call to https://localhost:44313
    //observer / observerables
    var observable = this.httpObj.post("https://localhost:44313/Customer/Add",this.customerObj);

    observable.subscribe(
      res=>this.Success(res),
      res=>this.Error(res)
    );
 }
 //Success function and error function
 // are interested to subscribe to the stream
 Success(res:any){

 }
 Error(res:any){

 }
}
