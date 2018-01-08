import {
    ReactiveFormsModule,
    NG_VALIDATORS,
    FormsModule,
    FormGroup,
    FormControl,
    ValidatorFn,
    Validator
} from '@angular/forms';

import { Directive } from '@angular/core';
import {DateValidator} from "../../modules/tasks/components/task-form/task-form.component";

@Directive({
    selector: '[datevalidator][ngModel]',
    providers: [
        {
            provide: NG_VALIDATORS,
            useExisting: DateValidator,
            multi: true
        }
    ]
})

export class DateVaxslidator implements Validator {
    validator: ValidatorFn;
    constructor() {
        this.validator = this.dateValidator();
    }
    validate(c: FormControl) {
        return this.validator(c);
    }
    dateValidator(): ValidatorFn {
        console.log("Waliduje")
        return (c: FormControl) => {
            let isValid = 2 > 3
            if (isValid) {
                return null;
            } else {
                return {
                    datevalidator: {
                        valid: false
                    }
                };
            }
        }
    }
}