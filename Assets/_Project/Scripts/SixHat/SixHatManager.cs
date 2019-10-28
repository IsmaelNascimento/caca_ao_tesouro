using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SixHatManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private Text m_QuestionCurrent;
    [Space(10)]
    [Header("Screen Result")]
    [SerializeField] private GameObject m_PanelResult;
    [SerializeField] private Text m_TextPoints;
    [SerializeField] private Image m_ImageHatResult;
    [SerializeField] private Text m_TextResult;
    [SerializeField] private Sprite[] m_ImagesHats;
    private int m_IndexQuestionCurrent = 0;
    private bool m_IsPositive;
    private int m_PointsCurrent = 0;

    private List<string> m_Questions = new List<string>() {
        "Adoro me divertir sempre",
        "Analiso os fatos para ver de que lado eu fico",
        "Aprecio tudo que é novo",
        "Consigo me expressar bem com as palavras",
        "Cuido para não me machucar",
        "Desmostro meus sentimentos",
        "Digo palavras certas para ajudar no que é preciso",
        "Geralmente estou sempre sorrindo",
        "Gosto de ajudar os amigos",
        "Gosto de criar coisas",
        "Gosto de dar explicações quando é necessário",
        "Gosto de ouvir as pessoas",
        "Não costumo falar o que penso às pessoas",
        "Passo tranquilidade às pessoas",
        "Penso antes de fazer qualquer coisa",
        "Percebo quando erro",
        "Presto atenção em tudo que é preciso",
        "Sempre penso que vai melhorar"
    };

    #endregion

    private void Start()
    {
        m_QuestionCurrent.text = m_Questions[m_IndexQuestionCurrent];
    }

    private void SendEmail(string resultStudent, string colorHat)
    {
        var subjectEmail = "Acompanhameto Caça ao Tesouro";
        var bodyEmail = string.Format("Resultado do aluno {0} no jogo: Seis chapeus\nCor do chapéu: {1}\nMensagem: {2}",
            InformationEmailManager.nameStudent, colorHat, resultStudent);

        SimpleEmailSender.Send(InformationEmailManager.emailTeacher, subjectEmail, bodyEmail, "", (x, y) => print("Send"));
        SimpleEmailSender.Send("falecom@cresceraprendendo.com.br", subjectEmail, bodyEmail, "", (x, y) => print("Send"));
    }

    private void ShowResult()
    {
        m_PanelResult.SetActive(true);
        m_TextPoints.text = m_PointsCurrent.ToString();
        var colorHat = "";
        var messageHat = "";

        if(m_PointsCurrent >= 0 && m_PointsCurrent <= 7)
        {
            m_ImageHatResult.sprite = m_ImagesHats[0];
            m_TextResult.text = "Parabéns! Você é super disciplinado(a) !";
            messageHat = m_TextResult.text;
            colorHat = "Azul";
        }
        else if (m_PointsCurrent >= 8 && m_PointsCurrent <= 19)
        {
            m_ImageHatResult.sprite = m_ImagesHats[1];
            m_TextResult.text = "Parabéns! Você é super Perseverante !";
            messageHat = m_TextResult.text;
            colorHat = "Preto";
        }
        else if (m_PointsCurrent >= 20 && m_PointsCurrent <= 34)
        {
            m_ImageHatResult.sprite = m_ImagesHats[2];
            m_TextResult.text = "Parabéns! Você sabe administrar Conflitos!";
            messageHat = m_TextResult.text;
            colorHat = "Branco";
        }
        else if (m_PointsCurrent >= 35 && m_PointsCurrent <= 44)
        {
            m_ImageHatResult.sprite = m_ImagesHats[3];
            m_TextResult.text = "Parabéns! Você é super Comunicativo(a) e Cooperativo(a) !";
            messageHat = m_TextResult.text;
            colorHat = "Amarelo";
        }
        else if (m_PointsCurrent >= 45 && m_PointsCurrent <= 53)
        {
            m_ImageHatResult.sprite = m_ImagesHats[4];
            m_TextResult.text = "Parabéns! Você tem uma capacidade de superação !";
            messageHat = m_TextResult.text;
            colorHat = "Verde";
        }
        else if (m_PointsCurrent >= 54 && m_PointsCurrent <= 63)
        {
            m_ImageHatResult.sprite = m_ImagesHats[5];
            m_TextResult.text = "Parabéns! Você é expert em dar Reconhecimento e é super Cooperativo(a) !";
            messageHat = m_TextResult.text;
            colorHat = "Vermelho";
        }

        SendEmail(messageHat, colorHat);
    }

    #region Buttons

    public void SetNextQuestion()
    {
        m_IndexQuestionCurrent++;

        if(m_IndexQuestionCurrent >= m_Questions.Count)
        {
            ShowResult();
        }
        else
        {
            m_QuestionCurrent.text = m_Questions[m_IndexQuestionCurrent];
        }
    }

    public void VerifyWhatQuestion(Text textQuestionCurrent)
    {
        var questionCurrent = textQuestionCurrent.text;

        switch (questionCurrent)
        {
            case "Adoro me divertir sempre":  m_PointsCurrent += 6;
                break;
            case "Analiso os fatos para ver de que lado eu fico":  m_PointsCurrent += 3;
                break;
            case "Aprecio tudo que é novo":  m_PointsCurrent += 5;
                break;
            case "Consigo me expressar bem com as palavras":  m_PointsCurrent += 1;
                break;
            case "Cuido para não me machucar":  m_PointsCurrent += 3;
                break;
            case "Desmostro meus sentimentos":  m_PointsCurrent += 4;
                break;
            case "Digo palavras certas para ajudar no que é preciso":  m_PointsCurrent += 6;
                break;
            case "Geralmente estou sempre sorrindo":  m_PointsCurrent += 6;
                break;
            case "Gosto de ajudar os amigos":  m_PointsCurrent += 4;
                break;
            case "Gosto de criar coisas":  m_PointsCurrent += 5;
                break;
            case "Gosto de dar explicações quando é necessário":  m_PointsCurrent += 2;
                break;
            case "Gosto de ouvir as pessoas":  m_PointsCurrent += 4;
                break;
            case "Não costumo falar o que penso às pessoas":  m_PointsCurrent += 2;
                break;
            case "Passo tranquilidade às pessoas":  m_PointsCurrent += 3;
                break;
            case "Penso antes de fazer qualquer coisa":  m_PointsCurrent += 1;
                break;
            case "Percebo quando erro":  m_PointsCurrent += 2;
                break;
            case "Presto atenção em tudo que é preciso":  m_PointsCurrent += 1;
                break;
            case "Sempre penso que vai melhorar":  m_PointsCurrent += 5;
                break;
        }
    }

    public void OnButtonGamesClicked()
    {
        SceneManager.LoadScene("MenuGames");
    }

    #endregion

}
