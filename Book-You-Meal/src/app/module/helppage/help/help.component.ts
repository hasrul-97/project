import { Component, OnInit } from '@angular/core';
import { EmailService } from 'src/app/shared/services/email.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
@Component({
  selector: 'app-help',
  templateUrl: './help.component.html',
  styleUrls: ['./help.component.css']
})
export class HelpComponent implements OnInit {
  constructor(private email: EmailService, private router: Router, private spinner: NgxSpinnerService) { }
  ngOnInit() {
  }

  roleName = localStorage.getItem("roleName").length>0?localStorage.getItem("roleName").toLowerCase():"";
  sendEmail(form: NgForm) {
    this.spinner.show();
    this.email.sendEmail(form.value.name, form.value.surname, form.value.message, form.value.need, form.value.email).subscribe((data) => {
      this.spinner.hide();
      alert("We have recorded your request. We will get back to you shortly.");
      this.router.navigate([this.roleName + '/home']);
    }, (error) => {
      alert(error.error["message"]);
    });
  }
}
