ppipeline {
    agent any

    stages {
        stage('Check Job 1 Trigger') {
            steps {
                script {
                    // Get Job 1 details using Jenkins' built-in API
                    def job1 = Jenkins.instance.getItem('start jenkins')
                    
                    if (job1) {
                        def lastBuild = job1.getLastBuild()
                        
                        if (lastBuild) {
                            def parametersAction = lastBuild.getAction(hudson.model.ParametersAction)
                            def triggerMode = parametersAction?.parameters?.find { it.name == 'trigger_mode' }?.value

                            if (triggerMode == 'auto') {
                                echo 'Job 1 was triggered automatically. Proceeding to trigger Job 2.'
                                build job: 'TEST UI'
                            } else {
                                echo 'Job 1 was not triggered automatically or parameter not found.'
                            }
                        } else {
                            echo 'No builds found for Job 1.'
                        }
                    } else {
                        echo 'Job 1 not found.'
                    }
                }
            }
        }

        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        
        stage('Update NuGet Package') {
            steps {
                dir('C:/Users/User/.jenkins/workspace/TEST UI/Automation Exercise') {
                    bat 'dotnet add package Selenium.WebDriver.ChromeDriver'
                }
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet restore "Automation Exercise.sln"'
                bat 'dotnet build "Automation Exercise.sln" --configuration Release'
            }
        }

        stage('Run Tests') {
            steps {
                bat 'dotnet test "Automation Exercise/AutomationExercise.csproj" --configuration Release'
            }
        }
    }

    post {
        always {
            script {
                bat 'taskkill /F /IM chrome.exe'
            }
        }
    }
}
