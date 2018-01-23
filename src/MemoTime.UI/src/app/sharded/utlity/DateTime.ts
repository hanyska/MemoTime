export class DateTime {
    static createByNumbers(year: number, month: number, day: number): Date {
        let date_str = this.createDateString(year, month, day)

        return new Date(date_str)
    }

    static createDateString(year: number, month: number, day: number): string {
        if (month < 10) {
            month = "0"+month
        }

        if (day < 9) {
            day = "0"+day
        }

        return year+"-"+month+"-"+day
    }

    static creteByString(str: string) {
        return new Date(str)
    }
}