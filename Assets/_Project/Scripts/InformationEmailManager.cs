using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class InformationEmailManager : MonoBehaviour
{
    [SerializeField] private InputField m_NameStudent;
    [SerializeField] private InputField m_AgeStudent;
    [SerializeField] private InputField m_SchoolStudent;
    [SerializeField] private InputField m_EmailTeacher;

    public static string nameStudent;
    public static int ageStudent;
    public static string schoolStudent;
    public static string emailTeacher;

    private void Start()
    {
        nameStudent = "";
        ageStudent = 0;
        schoolStudent = "";
        emailTeacher = "";

        SimpleEmailSender.emailSettings.STMPClient = "smtp-mail.outlook.com";
        SimpleEmailSender.emailSettings.SMTPPort = 587;
        SimpleEmailSender.emailSettings.UserName = "xxx@xxx.com";
        SimpleEmailSender.emailSettings.UserPass = "xxx";
    }

    public void OnButtonNextStepClicked(string scene)
    {
        if(string.IsNullOrEmpty(m_NameStudent.text) || string.IsNullOrEmpty(m_AgeStudent.text) || 
            string.IsNullOrEmpty(m_SchoolStudent.text) || string.IsNullOrEmpty(m_EmailTeacher.text))
        {
            return;
        }

        SendEmail();

        SceneManager.LoadScene(scene);
    }

    private void SendEmail()
    {
        nameStudent = m_NameStudent.text;
        ageStudent = int.Parse(m_AgeStudent.text);
        schoolStudent = m_SchoolStudent.text;
        emailTeacher = m_EmailTeacher.text;

        var subjectEmail = "Acompanhameto Caça ao Tesouro";
        var bodyEmail = string.Format("Aluno {0}, com idade de {1}, da escola {2}, começou a jogar na data e hora de {3}", 
            m_NameStudent.text, m_AgeStudent.text, m_SchoolStudent.text, DateTime.Now.ToString("pt-BR"));

        SimpleEmailSender.Send(emailTeacher, subjectEmail, bodyEmail, "", (x, y) => print("Send"));
        SimpleEmailSender.Send("falecom@cresceraprendendo.com.br", subjectEmail, bodyEmail, "", (x, y) => print("Send"));
    }
}
