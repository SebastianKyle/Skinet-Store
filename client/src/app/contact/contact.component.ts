import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ContactService } from './contact.service';
import { ToastrModule, ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss']
})
export class ContactComponent implements OnInit {
  contactForm: FormGroup;

  constructor(private fb: FormBuilder, private contactService: ContactService, private toastr: ToastrService) {

  }

  ngOnInit(): void {
    this.createContactForm();
  }

  createContactForm() {
    this.contactForm = this.fb.group({
      FullName: ['', Validators.required],
      Email: ['', Validators.compose([Validators.required, Validators.email])],
      Comment: ['', Validators.required]
    });
  }

  onSubmit(contactForm) {
    console.log(contactForm); 
    this.toastr.success('Submitted successfully');
  }

}
