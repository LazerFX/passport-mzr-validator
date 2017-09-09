import { HttpClient } from 'aurelia-fetch-client'
import { inject } from 'aurelia-framework'

@inject(HttpClient)
export class ServerApi {
    fetch: HttpClient;

    constructor(httpClient: HttpClient) {
        this.fetch = httpClient;
    }

    ValidateMzr(mzr: string): Promise<IMzrValidationResult> {
        return fetch(`api/MzrData/ValidateMzr?mzr=${mzr}`)
            .then(response => response.json())
            .then(data => {
                return data as IMzrValidationResult;
            })
            .catch(err => {
                return { valid: false, message: err.toString() };
            })
    }
}

export interface IMzrValidationResult {
    valid: boolean;
    message: string;
}