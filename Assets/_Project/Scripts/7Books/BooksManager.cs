using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BooksManager : MonoBehaviour
{
    private int m_NextQuestion = 0;

    [Header("UI")]
    [SerializeField] private GameObject m_PanelQuestions;
    [SerializeField] private Text m_TextButtonQuestions;
    [SerializeField] private GameObject m_ButtonQuestions;
    [SerializeField] private Text m_TextQuestion;
    [SerializeField] private InputField m_InputFieldAnswersUser;

    [Header("Sounds")]
    [SerializeField] private List<AudioSource> m_SoundBookChoosed;
    private bool m_IsPlayingNow = false;
    [Space(10)]

    [Header("Data mini game")]
    private int m_IdBookChoosed;
    private List<string> m_AnswersBookChoosed = new List<string>();
    private Dictionary<string, string> m_DataForSend = new Dictionary<string, string>();
    private string m_NameBookChoosed;

    private void Start()
    {
        m_TextButtonQuestions.text = "Próxima";
    }

    public void WhatThisBook(int idBook)
    {
        m_IdBookChoosed = idBook;
        m_PanelQuestions.SetActive(true);
        m_TextQuestion.text = QuestionsBookChoosed(idBook)[0];
    }

    public List<string> QuestionsBookChoosed(int idBook)
    {
        List<string> questionsBookChosed = new List<string>();

        switch (idBook)
        {
            case 0:
                m_NameBookChoosed = "A anfitriã";
                questionsBookChosed.Add("Como se sentia a árvore Anfitriã antes do prédio ser seu vizinho?");
                questionsBookChosed.Add("E depois que o prédio foi construído? Como se sentia?");
                questionsBookChosed.Add("O que aconteceu com os pássaros, seus amigos, antes e depois?");
                questionsBookChosed.Add("Qual foi o grande susto que a Anfitriã sofreu? Como ela se sentiu?");
                questionsBookChosed.Add("Quem salvou a Anfitriã?");
                questionsBookChosed.Add("Como você acha que a criança que salvou a Anfitriã se sentiu antes e depois de salvá-la?");
                questionsBookChosed.Add("Quais foram os pontos fortes ( competências da Roda da Aprendizagem) da criança ao salvar a árvore?");
                questionsBookChosed.Add("E você? Como pode melhorar estas competências para se tornar mais feliz?");
                break;
            case 1:
                m_NameBookChoosed = "Anita a menina sapeca";
                questionsBookChosed.Add("Como Anita se sentiu nas diferentes etapas da história: Quando estava a frente do shopping?");
                questionsBookChosed.Add("Como Anita se sentiu nas diferentes etapas da história: Quando a mãe disse não podia comprar?");
                questionsBookChosed.Add("Como Anita se sentiu nas diferentes etapas da história: Quando ela se encontrou com a bruxa, cobra, monstro?");
                questionsBookChosed.Add("Como Anita se sentiu nas diferentes etapas da história: Quando ela se deu conta que a presença da mãe era mais importante?");
                break;
            case 2:
                m_NameBookChoosed = "Delicias na escola";
                questionsBookChosed.Add("O que os pãezinhos estavam representando?");
                questionsBookChosed.Add("O que eles aprenderam ao serem cozidos?");
                questionsBookChosed.Add("Qual lição fica para as crianças?");
                questionsBookChosed.Add("O que elas conseguiram fazer no final da história?");
                questionsBookChosed.Add("Quais foram os pontos fortes (Roda da Aprendizagem) das crianças na história?");
                questionsBookChosed.Add("E você? O que pode fazer para melhorar estas competências para se tornar mais feliz?");
                break;
            case 3:
                m_NameBookChoosed = "Didi";
                questionsBookChosed.Add("Quem era Didi?");
                questionsBookChosed.Add("Por quê Didi não brincava com as crianças na rua?");
                questionsBookChosed.Add("O que as crianças queriam com Didi?");
                questionsBookChosed.Add("Quais foram as competências (Roda da Aprendizagem) das crianças na história?");
                questionsBookChosed.Add("E estas competências, como estão para você?");
                break;
            case 4:
                m_NameBookChoosed = "O pássaro Joaquim";
                questionsBookChosed.Add("O que deixava o Pássaro Joaquim triste?");
                questionsBookChosed.Add("O que ele queria conquistar?");
                questionsBookChosed.Add("Como ele descobriu o caminho para superar sua dificuldade?");
                questionsBookChosed.Add("Quais competências (Roda de Aprendizagem), como pontos fortes de Joaquim?");
                questionsBookChosed.Add("E você? Qual seu ponto forte, que pode desenvolver mais? Qual o ponto mais importante para você desenvolver e alcançar o que quer?");
                questionsBookChosed.Add("Depende só de você? Tem alguém que possa te ajudar?");
                questionsBookChosed.Add("O que pode fazer?");
                break;
            case 5:
                m_NameBookChoosed = "Rafinha";
                questionsBookChosed.Add("O que Rafinha fez no parque aquático?");
                questionsBookChosed.Add("Como ele imaginava que seria seu dia?");
                questionsBookChosed.Add("Qual foi a lição que ele teve quando se distanciou da família?");
                questionsBookChosed.Add("Quais as competências que Rafinha desenvolveu no final da história?");
                questionsBookChosed.Add("E você? Que competências pode desenvolver ?");
                break;
            case 6:
                m_NameBookChoosed = "Teló";
                questionsBookChosed.Add("O que aconteceu que Teló foi embora da casa que morava?");
                questionsBookChosed.Add("Como a família se sentiu? E Teló, como se sentiu?");
                questionsBookChosed.Add("Quais as competências (Roda da Aprendizagem) da família e de Teló?");
                questionsBookChosed.Add("O que Teló aprendeu?");
                questionsBookChosed.Add("O que a família aprendeu?");
                questionsBookChosed.Add("E você? Que competências precisa melhorar?");
                break;
        }

        return questionsBookChosed;
    } 

    private void SendEmail()
    {
        SimpleEmailSender.emailSettings.STMPClient = "smtp-mail.outlook.com";
        SimpleEmailSender.emailSettings.SMTPPort = 587;
        SimpleEmailSender.emailSettings.UserName = "ismaeln.business@outlook.com";
        SimpleEmailSender.emailSettings.UserPass = "123456fmA";

        var answers = "";

        for (int i = 0; i < QuestionsBookChoosed(m_IdBookChoosed).Count; i++)
        {
            answers += string.Format("Pergunta: {0}\nResposta: {1}\n", QuestionsBookChoosed(m_IdBookChoosed)[i], m_AnswersBookChoosed[i]);
        }

        var subjectEmail = "Acompanhameto Caça ao Tesouro";
        var bodyEmail = string.Format("As respostas do aluno {0} para o livro {1} foram:\n{2}",
            InformationEmailManager.nameStudent, m_NameBookChoosed, answers);

        SimpleEmailSender.Send(InformationEmailManager.emailTeacher, subjectEmail, bodyEmail, "", (x, y) => print("Send"));
        SimpleEmailSender.Send("falecom@cresceraprendendo.com.br", subjectEmail, bodyEmail, "", (x, y) => print("Send"));
    }

    public void SaveAnswerAndSendEmail()
    {
        SendEmail();
        SceneManager.LoadScene("MenuGames");
    }

    #region Buttons UI

    public void PlaySoundBookChoosed()
    {
        m_IsPlayingNow = !m_IsPlayingNow;

        if (m_IsPlayingNow)
        {
            m_SoundBookChoosed[m_IdBookChoosed].Stop();
        }
        else
        {
            m_SoundBookChoosed[m_IdBookChoosed].Play();
        }
    }

    public void NextOrFinishedQuestion()
    {
        m_AnswersBookChoosed.Add(m_InputFieldAnswersUser.text);
        m_InputFieldAnswersUser.text = string.Empty;

        m_NextQuestion++;

        if (m_NextQuestion < QuestionsBookChoosed(m_IdBookChoosed).Count)
        {
            m_TextQuestion.text = QuestionsBookChoosed(m_IdBookChoosed)[m_NextQuestion];
            m_TextButtonQuestions.text = "Próxima";
        }
        else
        {
            m_TextButtonQuestions.text = "Terminar";
            m_InputFieldAnswersUser.gameObject.SetActive(false);
            m_TextQuestion.text = string.Empty;
            StartCoroutine(FinishedQuestion_Corotine());
        }
    }

    IEnumerator FinishedQuestion_Corotine()
    {
        Destroy(m_ButtonQuestions.GetComponent<Button>());
        yield return new WaitForEndOfFrame();
        m_ButtonQuestions.AddComponent<Button>();
        m_ButtonQuestions.GetComponent<Button>().onClick.AddListener(SaveAnswerAndSendEmail);
    }
    #endregion
}