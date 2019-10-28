using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class WheelLearnig : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject m_ButtonSave;

    [Header("Empathy")]
    [SerializeField] private Image m_EmpathyBlue;
    [SerializeField] private Image m_EmpathyGreen;
    [SerializeField] private Image m_EmpathyRed;
    [Header("Cooperation")]
    [SerializeField]
    private Image m_CooperationBlue;
    [SerializeField] private Image m_CooperationGreen;
    [SerializeField] private Image m_CooperationRed;
    [Header("Conflicts")]
    [SerializeField]
    private Image m_ConflictsBlue;
    [SerializeField] private Image m_ConflictsGreen;
    [SerializeField] private Image m_ConflictsRed;
    [Header("Continuity")]
    [SerializeField]
    private Image m_ContinuityBlue;
    [SerializeField] private Image m_ContinuityGreen;
    [SerializeField] private Image m_ContinuityRed;
    [Header("Communication")]
    [SerializeField]
    private Image m_CommunicationBlue;
    [SerializeField] private Image m_CommunicationGreen;
    [SerializeField] private Image m_CommunicationRed;
    [Header("Overcoming")]
    [SerializeField]
    private Image m_OvercomingBlue;
    [SerializeField] private Image m_OvercomingGreen;
    [SerializeField] private Image m_OvercomingRed;
    [Header("Recognition")]
    [SerializeField]
    private Image m_RecognitionBlue;
    [SerializeField] private Image m_RecognitionGreen;
    [SerializeField] private Image m_RecognitionRed;
    [Header("Discipline")]
    [SerializeField]
    private Image m_DisciplineBlue;
    [SerializeField] private Image m_DisciplineGreen;
    [SerializeField] private Image m_DisciplineRed;

    #endregion

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var hit = Physics2D.Raycast(Input.mousePosition, Vector2.up);
            var hitClicked = hit.collider;

            if (hitClicked != null)
            {
                if (hitClicked.GetComponent<Empathy>())
                {
                    HitEmpathy(hitClicked.tag);
                }
                else if (hitClicked.GetComponent<Cooperation>())
                {
                    HitCooperation(hitClicked.tag);
                }
                else if (hitClicked.GetComponent<Conflicts>())
                {
                    HitConflicts(hitClicked.tag);
                }
                else if (hitClicked.GetComponent<Continuity>())
                {
                    HitContinuity(hitClicked.tag);
                }
                else if (hitClicked.GetComponent<Communication>())
                {
                    HitCommunication(hitClicked.tag);
                }
                else if (hitClicked.GetComponent<Overcoming>())
                {
                    HitOvercoming(hitClicked.tag);
                }
                else if (hitClicked.GetComponent<Recognition>())
                {
                    HitRecognition(hitClicked.tag);
                }
                else if (hitClicked.GetComponent<Discipline>())
                {
                    HitDiscipline(hitClicked.tag);
                }
            }
        }
    }

    private void HitEmpathy(string tag)
    {
        switch (tag)
        {
            case "Blue":
                m_EmpathyBlue.color = Color.blue;
                m_EmpathyGreen.color = Color.clear;
                m_EmpathyRed.color = Color.clear;
                break;
            case "Green":
                m_EmpathyBlue.color = Color.clear;
                m_EmpathyGreen.color = Color.green;
                m_EmpathyRed.color = Color.clear;
                break;
            case "Red":
                m_EmpathyBlue.color = Color.clear;
                m_EmpathyGreen.color = Color.clear;
                m_EmpathyRed.color = Color.red;
                break;
        }
    }

    private void HitCooperation(string tag)
    {
        switch (tag)
        {
            case "Blue":
                m_CooperationBlue.color = Color.blue;
                m_CooperationGreen.color = Color.clear;
                m_CooperationRed.color = Color.clear;
                break;
            case "Green":
                m_CooperationBlue.color = Color.clear;
                m_CooperationGreen.color = Color.green;
                m_CooperationRed.color = Color.clear;
                break;
            case "Red":
                m_CooperationBlue.color = Color.clear;
                m_CooperationGreen.color = Color.clear;
                m_CooperationRed.color = Color.red;
                break;
        }
    }

    private void HitConflicts(string tag)
    {
        switch (tag)
        {
            case "Blue":
                m_ConflictsBlue.color = Color.blue;
                m_ConflictsGreen.color = Color.clear;
                m_ConflictsRed.color = Color.clear;
                break;
            case "Green":
                m_ConflictsBlue.color = Color.clear;
                m_ConflictsGreen.color = Color.green;
                m_ConflictsRed.color = Color.clear;
                break;
            case "Red":
                m_ConflictsBlue.color = Color.clear;
                m_ConflictsGreen.color = Color.clear;
                m_ConflictsRed.color = Color.red;
                break;
        }
    }

    private void HitContinuity(string tag)
    {
        switch (tag)
        {
            case "Blue":
                m_ContinuityBlue.color = Color.blue;
                m_ContinuityGreen.color = Color.clear;
                m_ContinuityRed.color = Color.clear;
                break;
            case "Green":
                m_ContinuityBlue.color = Color.clear;
                m_ContinuityGreen.color = Color.green;
                m_ContinuityRed.color = Color.clear;
                break;
            case "Red":
                m_ContinuityBlue.color = Color.clear;
                m_ContinuityGreen.color = Color.clear;
                m_ContinuityRed.color = Color.red;
                break;
        }
    }

    private void HitCommunication(string tag)
    {
        switch (tag)
        {
            case "Blue":
                m_CommunicationBlue.color = Color.blue;
                m_CommunicationGreen.color = Color.clear;
                m_CommunicationRed.color = Color.clear;
                break;
            case "Green":
                m_CommunicationBlue.color = Color.clear;
                m_CommunicationGreen.color = Color.green;
                m_CommunicationRed.color = Color.clear;
                break;
            case "Red":
                m_CommunicationBlue.color = Color.clear;
                m_CommunicationGreen.color = Color.clear;
                m_CommunicationRed.color = Color.red;
                break;
        }
    }

    private void HitOvercoming(string tag)
    {
        switch (tag)
        {
            case "Blue":
                m_OvercomingBlue.color = Color.blue;
                m_OvercomingGreen.color = Color.clear;
                m_OvercomingRed.color = Color.clear;
                break;
            case "Green":
                m_OvercomingBlue.color = Color.clear;
                m_OvercomingGreen.color = Color.green;
                m_OvercomingRed.color = Color.clear;
                break;
            case "Red":
                m_OvercomingBlue.color = Color.clear;
                m_OvercomingGreen.color = Color.clear;
                m_OvercomingRed.color = Color.red;
                break;
        }
    }

    private void HitRecognition(string tag)
    {
        switch (tag)
        {
            case "Blue":
                m_RecognitionBlue.color = Color.blue;
                m_RecognitionGreen.color = Color.clear;
                m_RecognitionRed.color = Color.clear;
                break;
            case "Green":
                m_RecognitionBlue.color = Color.clear;
                m_RecognitionGreen.color = Color.green;
                m_RecognitionRed.color = Color.clear;
                break;
            case "Red":
                m_RecognitionBlue.color = Color.clear;
                m_RecognitionGreen.color = Color.clear;
                m_RecognitionRed.color = Color.red;
                break;
        }
    }

    private void HitDiscipline(string tag)
    {
        switch (tag)
        {
            case "Blue":
                m_DisciplineBlue.color = Color.blue;
                m_DisciplineGreen.color = Color.clear;
                m_DisciplineRed.color = Color.clear;
                break;
            case "Green":
                m_DisciplineBlue.color = Color.clear;
                m_DisciplineGreen.color = Color.green;
                m_DisciplineRed.color = Color.clear;
                break;
            case "Red":
                m_DisciplineBlue.color = Color.clear;
                m_DisciplineGreen.color = Color.clear;
                m_DisciplineRed.color = Color.red;
                break;
        }
    }

    public void OnButtonSaveWheelLearningClicked()
    {
        m_ButtonSave.SetActive(false);
        SendEmail();
        SceneManager.LoadScene("MenuGames");
    }

    private void SendEmail()
    {
        var nameScreenshot = "/WheelLearnig.png";
        var pathScreenshot = string.Concat(Application.dataPath, nameScreenshot);
        var subjectEmail = "Acompanhameto Caça ao Tesouro";
        var bodyEmail = string.Format("Segue em anexo a roda de aprendizagem do aluno {0} da escola {1} feito na data e hora {2}",
            InformationEmailManager.nameStudent, InformationEmailManager.schoolStudent, DateTime.Now);

        ScreenCapture.CaptureScreenshot(pathScreenshot);

        SimpleEmailSender.Send(InformationEmailManager.emailTeacher, subjectEmail, bodyEmail, "", (x, y) => print("Send"));
        SimpleEmailSender.Send("falecom@cresceraprendendo.com.br", subjectEmail, bodyEmail, "", (x, y) => print("Send"));
    }
}