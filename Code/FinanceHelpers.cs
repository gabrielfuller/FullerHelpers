using System;

namespace FullerHelpers
{
    public static class FinanceHelpers
    {
        public static decimal PrincipleAndInterest(
            decimal loanAmount,
            decimal taxesPerYear,
            decimal downPayment,
            decimal interestRate,
            decimal termOfLoan,
            decimal propertyTax,
            decimal insurance)
        {
            interestRate = (interestRate / 100);
            termOfLoan = termOfLoan * 12;

            // plug the values from the input into the mortgage formula
            decimal pow = Convert.ToDecimal(Math.Pow((double)(1 + interestRate / 12), (double)termOfLoan));
            decimal payment = (loanAmount - downPayment) * (pow * interestRate) / (12 * (pow - 1));

            // add on a monthly property tax and insurance
            payment = payment + (propertyTax + insurance) / 12;

            // place the monthly payment calculated into the output text field
            return payment;
        }


        public static decimal GetLoanPayoff(decimal LoanAmount, DateTime CloseDate, decimal Rate, int Term)
        {
            /*
            var origLoanAmount = new Number($('.OriginalLoanAmount').val().replace(/\$|\,/g, ''));
            var closedate = new Date($('.DeedOfTrustDate').val());
            var rate = new Number($('.OriginalRate').val().replace(/\%|\,/g, ''));
            var term = new Number($('.OriginalTerm').val());    
            if (origLoanAmount != 0 && closedate != null && rate != 0) {
                var bal = RemainingBalance(origLoanAmount, rate, term, closedate, new Date());
                $('.EstimatedLoanPayoff').val(formatCurrency(bal));
        
                var loanAmount = new Number();
                if ($('.secondlien:checked').size() > 0) {
                    //Calculate loan amount
                    var estHomeValue = new Number($('.EstimatedHomeValue').val().replace(/\$|\,/g, ''));
                    loanAmount = estHomeValue * .8;
                    $('.LoanAmount').val(formatCurrency(loanAmount));

                    var secondLoanAmount = bal - loanAmount;
                    $('.SecondLoanAmount').val(formatCurrency(secondLoanAmount));
                    $('.calccolumn .LoanAmount').change();
                }
                else {
                    loanAmount = new Number(bal);
                    $('.OriginalPandI').val(formatCurrency(PrincipleAndInterest(loanAmount,0,0,rate,term,0,0)));
                    $('.LoanAmount').val(formatCurrency(loanAmount));
                    $('.calccolumn .LoanAmount').change();
                }
            }*/

            return 0;
        }

        public static decimal RemainingBalance(decimal AmountBorrowed, decimal Rate, decimal Term, DateTime CloseDate, DateTime CurrentDate)
        {
            var DaysInMonth = 30.41666;
            var DaysSinceClosing = (CurrentDate - CloseDate).Days;
            var PaymentsSinceClosing = Math.Floor((DaysSinceClosing / DaysInMonth));
            var MonthlyPayment = FinanceHelpers.PrincipleAndInterest(AmountBorrowed, 0, 0, Rate, Term, 0, 0);
            var RateFactor = Rate / (12 * 100);
            var Balance = ((AmountBorrowed * (decimal)Math.Pow((double)(1 + RateFactor), PaymentsSinceClosing) - ((MonthlyPayment / RateFactor) * ((decimal)Math.Pow((double)(1 + RateFactor), PaymentsSinceClosing) - 1))));
            return Balance;
        }

        public static double GetVAFundingFee(double LoanAmount, VeteranType VeteranType, double DownPaymentPercentage, bool IsFirstTimeUse)
        {
            double Percentage = 0;
            if (VeteranType == FullerHelpers.VeteranType.RegularMilitary)
            {
                if (DownPaymentPercentage <= 0)
                {
                    if (IsFirstTimeUse == true)
                    {
                        Percentage = 2.15;
                    }
                    else
                    {
                        Percentage = 3.3;
                    }
                }
                else if (DownPaymentPercentage >= 5 && DownPaymentPercentage < 10)
                {
                    if (IsFirstTimeUse == true)
                    {
                        Percentage = 1.5;
                    }
                    else
                    {
                        Percentage = 1.5;
                    }
                }
                else if (DownPaymentPercentage >= 10)
                {
                    if (IsFirstTimeUse == true)
                    {
                        Percentage = 1.25;
                    }
                    else
                    {
                        Percentage = 1.25;
                    }
                }
            }
            else if (VeteranType == FullerHelpers.VeteranType.ReservesOrNationalGaurd)
            {
                if (DownPaymentPercentage <= 0)
                {
                    if (IsFirstTimeUse == true)
                    {
                        Percentage = 2.4;
                    }
                    else
                    {
                        Percentage = 3.3;
                    }
                }
                else if (DownPaymentPercentage >= 5 && DownPaymentPercentage < 10)
                {
                    if (IsFirstTimeUse == true)
                    {
                        Percentage = 1.75;
                    }
                    else
                    {
                        Percentage = 1.75;
                    }
                }
                else if (DownPaymentPercentage >= 10)
                {
                    if (IsFirstTimeUse == true)
                    {
                        Percentage = 1.5;
                    }
                    else
                    {
                        Percentage = 1.5;
                    }
                }
            }
            else if (VeteranType == FullerHelpers.VeteranType.DisabledVeteran)
            {
                Percentage = 0;
            }
            return (Percentage / 100) * LoanAmount;
        }


        public static decimal GetPrepaids(
            LoanPurpose LoanPurpose, 
            decimal PurchasePrice,
            decimal EstimatedHomeValue,
            decimal LoanAmount,  
            decimal InterestRate, 
            bool waiveEscrows)
        {
            var value = 0m;
    

            if (LoanPurpose == FullerHelpers.LoanPurpose.Purchase) 
            {
                if (waiveEscrows == false) 
                {
                    value += GetMonthlyInsurance(LoanPurpose, PurchasePrice, EstimatedHomeValue) * 3;
                    value += GetMonthlyTaxes(LoanPurpose, PurchasePrice, EstimatedHomeValue) * 3;
                }

                //Refi only needs 3 months insurance
                var Insurance = GetMonthlyInsurance(LoanPurpose, PurchasePrice, EstimatedHomeValue) * 12;
                var Interest = Get1DayOfInterest(LoanAmount, InterestRate) * 15;

                value += Insurance + Interest;
            }
            else
            {
                value += Get1DayOfInterest(LoanAmount, InterestRate);

                if (waiveEscrows == false) 
                {
                    value += GetMonthlyInsurance(LoanPurpose, PurchasePrice, EstimatedHomeValue) * 3;
                    value += GetMonthlyTaxes(LoanPurpose, PurchasePrice, EstimatedHomeValue) * 3;
                }
            }
            return value;
        }

        public static decimal GetMonthlyInsurance(LoanPurpose LoanPurpose, decimal PurchasePrice, decimal EstimatedHomeValue)
        {
            var value = 0m;
            if (LoanPurpose == FullerHelpers.LoanPurpose.Purchase) 
            {
                value = PurchasePrice;
            }
            else if(LoanPurpose == FullerHelpers.LoanPurpose.Refinance)
            {
                value = EstimatedHomeValue;
            }
            var insurance = (value * .00875m) / 12m;
            insurance = Math.Round(insurance * 100m) / 100m;
            return insurance;
        }

        public static decimal GetMonthlyTaxes(LoanPurpose LoanPurpose, decimal PurchasePrice, decimal EstimatedHomeValue)
        {
            var value = 0m;
            if (LoanPurpose == FullerHelpers.LoanPurpose.Purchase) 
            {
                value = PurchasePrice;
            }
            else if(LoanPurpose == FullerHelpers.LoanPurpose.Refinance)
            {
                value = EstimatedHomeValue;
            }
            var taxes = ((value * .025m) / 12m);
            taxes = Math.Round(taxes * 100m) / 100m;
            return taxes;
        }

        public static decimal Get1DayOfInterest(decimal LoanAmount, decimal InterestRate)
        {
            InterestRate = InterestRate / 100;
            return ((LoanAmount * InterestRate) / 360);
        }

        public static decimal GetPurchaseClosingCosts(
            decimal LoanAmount, 
            LoanType loanType, 
            bool AddSurvey, 
            bool GetHOATransfer, 
            VeteranType? VetType, 
            bool isVAFirstTime,
            decimal PurchasePrice,
            out decimal VAFundingPercent,
            out decimal VAFundingFee
        )
        {
            VAFundingFee = 0;
            VAFundingPercent = 0;

            return GetClosingCosts(LoanAmount, LoanPurpose.Purchase, loanType, AddSurvey, GetHOATransfer, isVAFirstTime, VetType, PurchasePrice, null, null, out VAFundingPercent, out VAFundingFee);

        }



        public static decimal GetClosingCosts(
            decimal LoanAmount, 
            LoanPurpose LoanPurpose, 
            LoanType LoanType, 
            bool AddSurvey, 
            bool GetHOATransfer,
            bool? IsVAFirstTime,
            VeteranType? VeteranType, 
            decimal? PurchasePrice,
            DateTime? OriginalCloseDate,
            decimal? EstimatedLoanPayoff,
            out decimal VAFundingPercent,
            out decimal VAFundingFee
            )
        {
            VAFundingFee = 0;
            VAFundingPercent = 0;
            var ClosingCosts = 0m;

            decimal
                SellerContributions = 0m,
                NonAllowableContributions = 1990m;
                
            bool IsCashOutRefi = false,
                T17 = true,
                T19 = true,
                T36 = true,
                R19 = true,
                R24 = true,
                T33 = true,
                T42 = true,
                T421 = true;

            if (AddSurvey == true)
            {
                var surveyCost = 200;
                ClosingCosts += surveyCost;
            }

            if (GetHOATransfer == true)
            {
                var HoaTransferFee = 100;
                ClosingCosts += HoaTransferFee;
            }

            if (LoanPurpose == FullerHelpers.LoanPurpose.Purchase)
            {
                ClosingCosts = 2465m;
                if (LoanType == FullerHelpers.LoanType.VA)
                {
                    SellerContributions = 1990;
                    VAFundingFee = GetVAFundingFee(LoanAmount, LoanPurpose, VeteranType.Value, 0, IsVAFirstTime.Value, out VAFundingFee, out VAFundingPercent);
                    ClosingCosts += VAFundingFee;
                }

                if (LoanAmount == 0 || PurchasePrice == 0)
                {
                    throw new Exception("Cannot be Zero");
                }
                else
                {

                }
            }
            else if(LoanPurpose == FullerHelpers.LoanPurpose.Refinance)
            {
                ClosingCosts += 2557.42m;
                if (LoanType == FullerHelpers.LoanType.VA)
                {
                    SellerContributions = 1990;
                    VAFundingFee = GetVAFundingFee(LoanAmount, LoanPurpose, VeteranType.Value, 0, IsVAFirstTime.Value, out VAFundingFee, out VAFundingPercent);
                    ClosingCosts += VAFundingFee;
                }

                if (LoanAmount == 0 || EstimatedLoanPayoff == 0 || OriginalCloseDate == null)
                {
                    throw new Exception("");
                }
            }
            return ClosingCosts;
        }

        private static decimal GetVAFundingFee(decimal _loanAmount, LoanPurpose LoanPurpose, VeteranType VeteranType, int p, bool IsVAFirstTime, out decimal VAFundingFee, out decimal VAFundingPercent)
        {
            VAFundingFee = 0m;
            VAFundingPercent = 0m;
            return 0m;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal GetPolicyRate(decimal value)
        {
            decimal policy = 0m;

            if (value <= 100000)
            {
                policy += GetSub100PolicyRate(value);
            }

            if (value > 100000 && value <= 1000000)
            {
                policy += 843;
                policy += Convert.ToInt32(Math.Ceiling((value - 100000.00m) * 0.00534m));
            }

            if (value > 1000001 && value <= 5000000)
            {
                policy += Convert.ToInt32(Math.Ceiling((value - 1000001m) * .00439m));
            }

            if (value > 5000001 && value <= 15000000)
            {
                policy += Convert.ToInt32(Math.Ceiling((value - 5000001m) * .00362m));
            }

            if (value > 15000001 && value <= 25000000)
            {
                policy += Convert.ToInt32(Math.Ceiling((value - 15000001m) * .00257m));
            }

            if (value > 25000001)
            {
                policy += Convert.ToInt32(Math.Ceiling((value - 25000001m) * .00154m));
            }
            return policy;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static decimal GetSub100PolicyRate(decimal amount)
        {
            if (amount <= 10000) { return 229; }
            else if (amount <= 10500) { return 233; }
            else if (amount <= 11000) { return 235; }
            else if (amount <= 11500) { return 239; }
            else if (amount <= 12000) { return 243; }
            else if (amount <= 12500) { return 246; }
            else if (amount <= 13000) { return 250; }
            else if (amount <= 13500) { return 254; }
            else if (amount <= 14000) { return 257; }
            else if (amount <= 14500) { return 260; }
            else if (amount <= 15000) { return 262; }
            else if (amount <= 15500) { return 266; }
            else if (amount <= 16000) { return 270; }
            else if (amount <= 16500) { return 274; }
            else if (amount <= 17000) { return 277; }
            else if (amount <= 17500) { return 281; }
            else if (amount <= 18000) { return 285; }
            else if (amount <= 18500) { return 287; }
            else if (amount <= 19000) { return 290; }
            else if (amount <= 19500) { return 293; }
            else if (amount <= 20000) { return 298; }
            else if (amount <= 20500) { return 301; }
            else if (amount <= 21000) { return 305; }
            else if (amount <= 21500) { return 308; }
            else if (amount <= 22000) { return 312; }
            else if (amount <= 22500) { return 315; }
            else if (amount <= 23000) { return 318; }
            else if (amount <= 23500) { return 321; }
            else if (amount <= 24000) { return 325; }
            else if (amount <= 24500) { return 328; }
            else if (amount <= 25000) { return 332; }
            else if (amount <= 25500) { return 335; }
            else if (amount <= 26000) { return 339; }
            else if (amount <= 26500) { return 342; }
            else if (amount <= 27000) { return 345; }
            else if (amount <= 27500) { return 348; }
            else if (amount <= 28000) { return 352; }
            else if (amount <= 28500) { return 355; }
            else if (amount <= 29000) { return 359; }
            else if (amount <= 29500) { return 362; }
            else if (amount <= 30000) { return 366; }
            else if (amount <= 30500) { return 369; }
            else if (amount <= 31000) { return 373; }
            else if (amount <= 31500) { return 376; }
            else if (amount <= 32000) { return 379; }
            else if (amount <= 32500) { return 383; }
            else if (amount <= 33000) { return 386; }
            else if (amount <= 33500) { return 390; }
            else if (amount <= 34000) { return 393; }
            else if (amount <= 34500) { return 397; }
            else if (amount <= 35000) { return 400; }
            else if (amount <= 35500) { return 404; }
            else if (amount <= 36000) { return 407; }
            else if (amount <= 36500) { return 410; }
            else if (amount <= 37000) { return 413; }
            else if (amount <= 37500) { return 417; }
            else if (amount <= 38000) { return 421; }
            else if (amount <= 38500) { return 425; }
            else if (amount <= 39000) { return 427; }
            else if (amount <= 39500) { return 431; }
            else if (amount <= 40000) { return 434; }
            else if (amount <= 40500) { return 438; }
            else if (amount <= 41000) { return 440; }
            else if (amount <= 41500) { return 445; }
            else if (amount <= 42000) { return 448; }
            else if (amount <= 42500) { return 452; }
            else if (amount <= 43000) { return 454; }
            else if (amount <= 43500) { return 458; }
            else if (amount <= 44000) { return 461; }
            else if (amount <= 44500) { return 465; }
            else if (amount <= 45000) { return 469; }
            else if (amount <= 45500) { return 472; }
            else if (amount <= 46000) { return 475; }
            else if (amount <= 46500) { return 479; }
            else if (amount <= 47000) { return 481; }
            else if (amount <= 47500) { return 485; }
            else if (amount <= 48000) { return 489; }
            else if (amount <= 48500) { return 493; }
            else if (amount <= 49000) { return 496; }
            else if (amount <= 49500) { return 499; }
            else if (amount <= 50000) { return 503; }
            else if (amount <= 50500) { return 506; }
            else if (amount <= 51000) { return 508; }
            else if (amount <= 51500) { return 512; }
            else if (amount <= 52000) { return 516; }
            else if (amount <= 52500) { return 520; }
            else if (amount <= 53000) { return 523; }
            else if (amount <= 53500) { return 527; }
            else if (amount <= 54000) { return 530; }
            else if (amount <= 54500) { return 533; }
            else if (amount <= 55000) { return 536; }
            else if (amount <= 55500) { return 539; }
            else if (amount <= 56000) { return 544; }
            else if (amount <= 56500) { return 547; }
            else if (amount <= 57000) { return 550; }
            else if (amount <= 57500) { return 554; }
            else if (amount <= 58000) { return 558; }
            else if (amount <= 58500) { return 560; }
            else if (amount <= 59000) { return 564; }
            else if (amount <= 59500) { return 567; }
            else if (amount <= 60000) { return 571; }
            else if (amount <= 60500) { return 575; }
            else if (amount <= 61000) { return 578; }
            else if (amount <= 61500) { return 581; }
            else if (amount <= 62000) { return 585; }
            else if (amount <= 62500) { return 589; }
            else if (amount <= 63000) { return 591; }
            else if (amount <= 63500) { return 594; }
            else if (amount <= 64000) { return 598; }
            else if (amount <= 64500) { return 602; }
            else if (amount <= 65000) { return 605; }
            else if (amount <= 65500) { return 608; }
            else if (amount <= 66000) { return 612; }
            else if (amount <= 66500) { return 617; }
            else if (amount <= 67000) { return 620; }
            else if (amount <= 67500) { return 621; }
            else if (amount <= 68000) { return 625; }
            else if (amount <= 68500) { return 629; }
            else if (amount <= 69000) { return 632; }
            else if (amount <= 69500) { return 635; }
            else if (amount <= 70000) { return 640; }
            else if (amount <= 70500) { return 644; }
            else if (amount <= 71000) { return 647; }
            else if (amount <= 71500) { return 649; }
            else if (amount <= 72000) { return 652; }
            else if (amount <= 72500) { return 656; }
            else if (amount <= 73000) { return 660; }
            else if (amount <= 73500) { return 663; }
            else if (amount <= 74000) { return 667; }
            else if (amount <= 74500) { return 671; }
            else if (amount <= 75000) { return 674; }
            else if (amount <= 75500) { return 676; }
            else if (amount <= 76000) { return 680; }
            else if (amount <= 76500) { return 683; }
            else if (amount <= 77000) { return 687; }
            else if (amount <= 77500) { return 690; }
            else if (amount <= 78000) { return 694; }
            else if (amount <= 78500) { return 698; }
            else if (amount <= 79000) { return 702; }
            else if (amount <= 79500) { return 703; }
            else if (amount <= 80000) { return 707; }
            else if (amount <= 80500) { return 711; }
            else if (amount <= 81000) { return 715; }
            else if (amount <= 81500) { return 717; }
            else if (amount <= 82000) { return 721; }
            else if (amount <= 82500) { return 725; }
            else if (amount <= 83000) { return 729; }
            else if (amount <= 83500) { return 731; }
            else if (amount <= 84000) { return 734; }
            else if (amount <= 84500) { return 739; }
            else if (amount <= 85000) { return 742; }
            else if (amount <= 85500) { return 745; }
            else if (amount <= 86000) { return 748; }
            else if (amount <= 86500) { return 752; }
            else if (amount <= 87000) { return 756; }
            else if (amount <= 87500) { return 759; }
            else if (amount <= 88000) { return 762; }
            else if (amount <= 88500) { return 766; }
            else if (amount <= 89000) { return 770; }
            else if (amount <= 89500) { return 772; }
            else if (amount <= 90000) { return 775; }
            else if (amount <= 90500) { return 779; }
            else if (amount <= 91000) { return 783; }
            else if (amount <= 91500) { return 787; }
            else if (amount <= 92000) { return 789; }
            else if (amount <= 92500) { return 793; }
            else if (amount <= 93000) { return 797; }
            else if (amount <= 93500) { return 801; }
            else if (amount <= 94000) { return 802; }
            else if (amount <= 94500) { return 806; }
            else if (amount <= 95000) { return 811; }
            else if (amount <= 95500) { return 814; }
            else if (amount <= 96000) { return 816; }
            else if (amount <= 96500) { return 820; }
            else if (amount <= 97000) { return 824; }
            else if (amount <= 97500) { return 828; }
            else if (amount <= 98000) { return 830; }
            else if (amount <= 98500) { return 834; }
            else if (amount <= 99000) { return 838; }
            else if (amount <= 99500) { return 841; }
            else if (amount <= 100000) { return 843; }
            else { return 843; }
        }

        /// <summary>
        /// Title Policy Discount
        /// </summary>
        /// <param name="DeedOfTrustDate"></param>
        /// <param name="LenderTitlePolicy"></param>
        /// <param name="MortgageBalance"></param>
        /// <param name="DiscountRate"></param>
        /// <returns></returns>
        public static decimal GetTitlePolicyDiscount(DateTime DeedOfTrustDate, decimal LenderTitlePolicy, decimal MortgageBalance, out decimal DiscountRate)
        {
            decimal BalancePolicyCost = GetPolicyRate(MortgageBalance);

            TimeSpan ts = DateTime.Now - DeedOfTrustDate;
            decimal Years = Convert.ToDecimal(ts.Days / (30.4166666 * 12));
            DiscountRate = 0;
            decimal DiscountValue = 0m;
            if (Years <= 2)
            {
                DiscountRate = 0.4m;
            }
            else if (Years > 2 && Years <= 3)
            {
                DiscountRate = 0.35m;
            }
            else if (Years > 3 && Years <= 4)
            {
                DiscountRate = 0.30m;
            }
            else if (Years > 4 && Years <= 5)
            {
                DiscountRate = 0.25m;
            }
            else if (Years > 5 && Years <= 6)
            {
                DiscountRate = 0.20m;
            }
            else if (Years > 6 && Years <= 7)
            {
                DiscountRate = 0.15m;
            }
            DiscountValue = DiscountRate * BalancePolicyCost;
            return DiscountValue;
        }

        public class ClosingCost
        {
            public string Name { get; set; }
            public decimal Cost { get; set; }
        }
    }
}