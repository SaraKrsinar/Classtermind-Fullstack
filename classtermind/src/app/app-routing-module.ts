import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SubjectListComponent } from './components/subject-list/subject-list.component';
import { AddSubjectComponent } from './components/add-subject/add-subject.component';
import { SubjectDetailComponent } from './components/subject-detail/subject-detail.component';

const routes: Routes = [
  { path: '', redirectTo: 'subjects', pathMatch: 'full' },
  { path: 'subjects', component: SubjectListComponent },
  { path: 'subjects/add', component: AddSubjectComponent },
  { path: 'subjects/:name', component: SubjectDetailComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
