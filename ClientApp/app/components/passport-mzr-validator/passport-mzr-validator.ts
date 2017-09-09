import { ServerApi, IMzrValidationResult } from "../../server-api/server-api";
import { inject } from 'aurelia-framework'

@inject(ServerApi)
export class PassportMzrValidator {
    title: string = "Validator";
    validationResult: IMzrValidationResult;
    serverApi: ServerApi;
    validationValue: string = "";

    constructor(serverApi: ServerApi) {
        this.serverApi = serverApi;
        this.validationResult = { message: "No Validation Attempted", valid: false };
    }

    ValidateMzr(): void {
        this.serverApi.ValidateMzr(this.validationValue)
            .then(result => this.validationResult = result);
        this.validationValue = "";
    }
}