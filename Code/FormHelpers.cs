using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace FullerHelpers
{
    public static class FormHelpers
    {
        public static MvcHtmlString CreditCardMonthExpirationDropdown(this HtmlHelper html, string name, int? selectedItem)
        {
            StringBuilder tags = new StringBuilder();
            for (int x = 1; x <= 12; x++)
            {
                var option = new TagBuilder("option");
                option.InnerHtml = x.ToString();
                option.Attributes["value"] = x.ToString();
                if (selectedItem.HasValue == true)
                {
                    if (selectedItem == x)
                    {
                        option.Attributes["selected"] = "selected";
                    }
                }
                tags.Append(option.ToString());
            }

            var select = new TagBuilder("select");
            select.Attributes["id"] = name;
            select.Attributes["name"] = name.Replace("_", ".");
            select.InnerHtml = tags.ToString();
            return MvcHtmlString.Create(select.ToString());
        }

        public static MvcHtmlString CreditCardMonthExpirationDropdownFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            Func<TModel, TValue> method = expression.Compile();
            int value = Convert.ToInt32(method(html.ViewData.Model).ToString());

            string expressionName = expression.Body.ToString();
            string[] names = expressionName.Split('.');
            int nameCount = names.Count();

            string id = "";
            for (int x = 1; x < nameCount; x++)
            {
                id += names.ElementAt(x);
                if (x != (nameCount - 1))
                {
                    id += "_";
                }
            }
            return MvcHtmlString.Create(CreditCardMonthExpirationDropdown(html, id, value).ToString());
        }

        public static MvcHtmlString CreditCardYearExpirationDropdown(this HtmlHelper html, string name, int? selectedItem)
        {
            StringBuilder tags = new StringBuilder();
            int yearsToCreate = 10;
            int currentYear = DateTime.Now.Year;
            int finalYear = currentYear + yearsToCreate;

            for (int x = currentYear; x <= finalYear; x++)
            {
                var option = new TagBuilder("option");
                option.InnerHtml = x.ToString();
                option.Attributes["value"] = x.ToString();
                if (selectedItem.HasValue == true)
                {
                    if (selectedItem == x)
                    {
                        option.Attributes["selected"] = "selected";
                    }
                }
                tags.Append(option.ToString());
            }

            var select = new TagBuilder("select");
            select.Attributes["id"] = name;
            select.Attributes["name"] = name.Replace("_", ".");
            select.InnerHtml = tags.ToString();
            return MvcHtmlString.Create(select.ToString());
        }

        public static MvcHtmlString CreditCardYearExpirationDropdownFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            Func<TModel, TValue> method = expression.Compile();
            int value = Convert.ToInt32(method(html.ViewData.Model).ToString());

            string expressionName = expression.Body.ToString();
            string[] names = expressionName.Split('.');
            int nameCount = names.Count();

            string id = "";
            for (int x = 1; x < nameCount; x++)
            {
                id += names.ElementAt(x);
                if (x != (nameCount - 1))
                {
                    id += "_";
                }
            }
            return MvcHtmlString.Create(CreditCardYearExpirationDropdown(html, id, value).ToString());
        }


        public static MvcHtmlString USStateDropDropdownFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            Func<TModel, TValue> method = expression.Compile();
            var item = method(html.ViewData.Model);
            string value = item == null ? null : item.ToString();

            string expressionName = expression.Body.ToString();
            string[] names = expressionName.Split('.');
            int nameCount = names.Count();

            string id = "";
            for (int x = 1; x < nameCount; x++)
            {
                id += names.ElementAt(x);
                if (x != (nameCount - 1))
                {
                    id += "_";
                }
            }
            return MvcHtmlString.Create(USStateDropDropdown(html, id, value).ToString());
        }

        public static MvcHtmlString USStateDropDropdown(this HtmlHelper html, string name, string SelectedValue)
        {
            var states = LocationData.US_STATES;

            StringBuilder tags = new StringBuilder();
            foreach (var item in states)
            {
                var option = new TagBuilder("option");
                option.InnerHtml = item.Name;
                option.Attributes["value"] = item.Abbreviation;
                if (SelectedValue != null)
                {
                    if (SelectedValue.ToLower() == item.Abbreviation.ToLower())
                    {
                        option.Attributes["selected"] = "selected";
                    }
                }
                tags.Append(option.ToString());
            }

            var select = new TagBuilder("select");
            select.Attributes["id"] = name;
            select.Attributes["name"] = name.Replace("_", ".");
            select.InnerHtml = tags.ToString();

            return MvcHtmlString.Create(select.ToString());
        }


        public static MvcHtmlString CountryDropdownFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, bool SortByNorthAmerica, bool USOnly)
        {
            Func<TModel, TValue> method = expression.Compile();
            var item = method(html.ViewData.Model);
            string value = item == null ? null : item.ToString();

            string expressionName = expression.Body.ToString();
            string[] names = expressionName.Split('.');
            int nameCount = names.Count();

            string id = "";
            for (int x = 1; x < nameCount; x++)
            {
                id += names.ElementAt(x);
                if (x != (nameCount - 1))
                {
                    id += "_";
                }
            }
            return MvcHtmlString.Create(CountryDropdown(html, id, value, SortByNorthAmerica, USOnly).ToString());
        }

        public static MvcHtmlString CountryDropdown(this HtmlHelper html, string name, string SelectedValue, bool SortByNorthAmerica, bool USOnly)
        {
            var countries = LocationData.Countries.ToList();
            if (SortByNorthAmerica == true)
            {
                countries = countries.OrderByDescending(m => m.SortOrder).ToList();
            }
            if (USOnly == true)
            {
                countries = countries.Where(c => c.Abbreviation.ToLower() == "us").ToList();
            }

            StringBuilder tags = new StringBuilder();
            foreach (var item in countries)
            {
                var option = new TagBuilder("option");
                option.InnerHtml = item.Name;
                option.Attributes["value"] = item.Abbreviation;
                if (SelectedValue != null)
                {
                    if (SelectedValue.ToLower() == item.Abbreviation.ToLower())
                    {
                        option.Attributes["selected"] = "selected";
                    }
                }
                tags.Append(option.ToString());
            }

            TagBuilder select = new TagBuilder("select");
            select.Attributes["id"] = name;
            select.Attributes["name"] = name.Replace("_", ".");
            select.InnerHtml = tags.ToString();

            return MvcHtmlString.Create(select.ToString());
        }


        public static bool GetBoolFromForm(string FormName, FormCollection form)
        {
            try
            {
                string value = form[FormName].ToString().ToLower();
                if (value == "false")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
