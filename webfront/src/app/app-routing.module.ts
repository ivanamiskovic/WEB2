import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddSafetyDocumentComponent } from './add-safety-document/add-safety-document.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { SafetyDocumentViewComponent } from './safety-document-view/safety-document-view.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'registration', component: RegistrationComponent },
  { path: 'add-safety-document', component: AddSafetyDocumentComponent },
  { path: 'view-safety-document', component: SafetyDocumentViewComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
