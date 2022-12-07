using pim_desktop.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace pim_desktop.Validators
{
    public class Validadores
    {
        public static bool CpfValidator(string text)
        {
            bool isNumeric = Regex.IsMatch(text, @"^\d");
            if (text.Length == 11 && text != "" && text != null && isNumeric)
               return true;
            else
                return false;
        }
        public static bool CnpjValidator(string text)
        {
            bool isNumeric = Regex.IsMatch(text, @"^\d");
            if (text.Length == 14 && text != "" && text != null && isNumeric)
                return true;
            else
                return false;
        }

        public static bool CnhValidator(string text)
        {
            bool isNumeric = Regex.IsMatch(text, @"^\d");
            if (text.Length == 11 && text != "" && text != null && isNumeric)
                return true;
            else
                return false;
        }

        public static bool RgValidator(string text)
        {
            bool isNumeric = Regex.IsMatch(text, @"^\d");
            if (text.Length >= 7 && text.Length <= 9 && text != "" && text != null && isNumeric)
                return true;
            else
                return false;
        }

        public static bool TelefoneValidator(string text)
        {
            bool isNumeric = Regex.IsMatch(text, @"^\d");
            if (text.Length == 11 && text != "" && text != null && isNumeric)
                return true;
            else
                return false;
        }

        public static bool CepValidator(string text)
        {
            bool isNumeric = Regex.IsMatch(text, @"^\d");
            if (text.Length == 8 && text != "" && text != null && isNumeric)
                return true;
            else
                return false;
        }

        public static bool NumberValidator(string text)
        {
            bool isNumeric = Regex.IsMatch(text, @"^\d");
            if (text != "" && text != null && isNumeric)
                return true;
            else
                return false;
        }

        public static bool EmailValidator(string text)
        {
            bool isEmail = Regex.IsMatch(text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            if (text.Length > 1 && text != "" && text != null && isEmail)
                return true;
            else
                return false;
        }

        public static bool TextValidator(string text)
        {
            if (text.Length > 1 && text != "" && text != null)
                return true;
            else
                return false;
        }

        public static bool MuilLineValidator(string text)
        {
            if (text.Length > 1 && text != "" && text != null && text.Length <= 200)
                return true;
            else
                return false;
        }

        public static bool SexoValidator(ComboBox sexo)
        {
            if ((Sexo)sexo.SelectedIndex == Sexo.Masculino || (Sexo)sexo.SelectedIndex == Sexo.Masculino)
                return true;
            else
         
                return false;
        }
        public static bool EstadoCivilValidator(ComboBox estadoCivil)
        {
            if ((EstadoCivil)estadoCivil.SelectedIndex == EstadoCivil.Solteiro ||
                (EstadoCivil)estadoCivil.SelectedIndex == EstadoCivil.Casado ||
                (EstadoCivil)estadoCivil.SelectedIndex == EstadoCivil.Divorciado ||
                (EstadoCivil)estadoCivil.SelectedIndex == EstadoCivil.Viuvo )
                return true;
            else
                return false;
        }
        public static bool ComboxValidator(ComboBox dropdown)
        {
            if (dropdown.SelectedIndex != -1)
                return true;
            else

                return false;
        }

        public static bool MenorDeIdadeValidator(DateTime dtNascimento)
        {
            int idade = DateTime.Now.Year - dtNascimento.Year;
            if (idade >= 18)
                return true;
            else
                return false;
        }
    }
}
