import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {RegistrationComponent} from './components/authorization/registration/registration.component';
import {LoginComponent} from './components/authorization/login/login.component';
import {ProfileComponent} from './components/user-profile/profile/profile.component';
import {NotFoundComponent} from './components/not-found/not-found.component';
import {AdminProfileComponent} from './components/admin-profile/admin-profile.component';
import {CategoriesComponent} from './components/categories/categories.component';
import {SubcategoryComponent} from './components/subcategory/subcategory.component';
import {SearchComponent} from './components/search/search.component';
import {CourseComponent} from './components/course-learn/course/course.component';
import {TaskComponent} from './components/course-learn/task/task.component';
import {AssessmentTaskComponent} from './components/course-learn/assessment-task/assessment-task.component';
import {CourseDetailedComponent} from './components/course-learn/course-detailed/course-detailed.component';
import {MainComponent} from './components/main/main.component';

const routes: Routes = [
  {path: '', component: MainComponent},
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegistrationComponent},
  {path: 'user/:id', component: ProfileComponent},
  {path: 'admin-profile/:id', component: AdminProfileComponent},
  {
    path: 'categories', component: CategoriesComponent,
    children: [
      {path: ':name', component: SubcategoryComponent}
    ]
  },
  {path: 'search', component: SearchComponent},
  {path: 'course', component: CourseComponent},
  {
    path: 'course-detailed/:id', component: CourseDetailedComponent,
    children: [
      {path: 'task/:id', component: TaskComponent},
      {path: 'assessment-task/:id', component: AssessmentTaskComponent},
    ]
  },
  {path: '**', component: NotFoundComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
